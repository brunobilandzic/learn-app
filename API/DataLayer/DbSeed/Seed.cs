using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.DataLayer.EfCode.DbSetup;
using API.DataLayer.Entities.Identity;
using API.DataLayer.Entities.Learning;
using API.DataLayer.Entities.StudentRelationships;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.DataLayer.DbSeed
{
    
    public class Seed
    {
        
        public static async Task SeedData(LearnAppDbContext context, UserManager<AppUser> userManager)
        {
            if(await context.Students.AnyAsync()) return; 

            var usersSerializedData =  await System.IO.File.ReadAllTextAsync("DataLayer/DbSeed/Users.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(usersSerializedData);
            var coursesSerializedData = await System.IO.File.ReadAllTextAsync("DataLayer/DbSeed/Courses.json");
            var courses = JsonSerializer.Deserialize<List<Course>>(coursesSerializedData);
             var lecturesSerializedData = await System.IO.File.ReadAllTextAsync("DataLayer/DbSeed/Lectures.json");
            var lectures = JsonSerializer.Deserialize<List<Lecture>>(lecturesSerializedData);

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "password");
            }

            foreach (var course in courses)
            {
                await context.Courses.AddAsync(course);
            }
            await context.SaveChangesAsync();

            var courseIds = await context.Courses.Select(c => c.CourseId).ToListAsync();

            var i = 0;
            foreach (var lecture in lectures)
            {
                lecture.CourseId = courseIds[i % courseIds.Count];
                i++;
                await context.Lectures.AddAsync(lecture);
            }

            foreach (var course in courses)
            {
                var firstExam = new Exam
                {
                    DateTimeStart = DateTime.Now.AddDays(50),
                    CourseId = course.CourseId
                };
                var secondExam = new Exam
                {
                    DateTimeStart = DateTime.Now.AddDays(150),
                    CourseId = course.CourseId
                };

                await context.AddAsync(firstExam);
                await context.AddAsync(secondExam);

            }

            await context.SaveChangesAsync();

            foreach (var user in users)
            {
                var coursesEnrolled = new List<int>(); // track courses enrolled, avoid duplicate PKs (FK1,FK2)
                var r = new Random();
                for(var coursesEnrolledCount = 0; coursesEnrolledCount < 6; coursesEnrolledCount++)
                {
                    int courseIndex;
                    while(true)
                    {
                        courseIndex = r.Next(courses.Count);
                        if(coursesEnrolled.Contains(courseIndex) == false)
                        {
                            var courseToEnrollId = courses[courseIndex].CourseId;
                            var examIds = await context.Exams
                                .Where(e => e.CourseId == courseToEnrollId)
                                .Select(e => e.ExamId)
                                .ToListAsync();
                            await context.StudentCourses
                                .AddAsync(new StudentCourse
                                {
                                    StudentId = user.Id,
                                    CourseId = courseToEnrollId
                                });
                            coursesEnrolled.Add(courseIndex);
                            /*
                            Connect the student with exams that course has
                            */
                            foreach (var examId in examIds)
                            {
                                await context.AddAsync(new StudentExam{
                                    StudentId = user.Id,
                                    ExamId = examId
                                });
                            }
                            break;
                        }
                    }
                }

                await context.SaveChangesAsync();

                /*******************************
                Student is now enrolled in 6 courses. Now we shall create some learning tasks
                For the student and then connect them with lectures of courses student is enrolled in.
                Lets make 2 learning tasks with 5 lectures for each student.
                If one lecture is in some learning task it shall not be in any other
                *******************************/
                
                for(var learningTaskCount = 0; learningTaskCount < 3; learningTaskCount ++)
                {
                    var newLearningTask = new LearningTask
                    {
                        Tag = CreateRandomTaskTagName(),
                        StudentId = user.Id,
                        Importance = r.Next(6),
                        DeadlineDate = DateTime.Now.AddMonths(r.Next(3))
                    };
                    await context.LearningTasks.AddAsync(newLearningTask);
                } 

                await context.SaveChangesAsync();
                

                /*
                Now we have 3 learning tasks for student
                What is needed is to connect them with some lectures
                Need to create and save 5 LectureLearningTasks
                */
                var learningTaskIds = await context.LearningTasks
                    .Where(lt => lt.StudentId == user.Id)
                    .Select(lt => lt.LearningTaskId)
                    .ToListAsync();

                var studentsCourseIds = await context.StudentCourses
                    .Where(sc => sc.StudentId == user.Id)
                    .Select(sc => sc.CourseId)
                    .ToListAsync();

                var allowedLectureIds = await context.Lectures
                    .Where(l => studentsCourseIds.Contains(l.CourseId))
                    .Select(l => l.LectureId)
                    .ToListAsync();

                
                var lecturesAlreadyInTasks = new List<int>();
                foreach (var learningTaskId in learningTaskIds)
                {
                    for(var lectureLearningTaskCount = 0; lectureLearningTaskCount < 5; lectureLearningTaskCount++)
                    {
                        while(true)
                        {
                            var lectureIndex = r.Next(allowedLectureIds.Count);
                            if(lecturesAlreadyInTasks.Contains(lectureIndex) == false)
                            {
                                var newLectureLearningTask = new LectureLearningTask
                                {
                                    LectureId = allowedLectureIds[lectureIndex],
                                    LearningTaskId = learningTaskId
                                };
                                await context.LectureLearningTasks.AddAsync(newLectureLearningTask);
                                lecturesAlreadyInTasks.Add(lectureIndex);
                                break;
                            }
                        }
                    }
                }

                await context.SaveChangesAsync();
            }
        }

        private static string CreateRandomTaskTagName()
        {
            var r = new Random();
            
            var length = r.Next(3,10);
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                var newChar = (char)r.Next(65,91);
                Console.WriteLine(newChar);
                chars[i]= newChar;                         
            }
            return new string(chars);
        }
    }
}