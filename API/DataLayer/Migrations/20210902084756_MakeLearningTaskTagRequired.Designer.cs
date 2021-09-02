﻿// <auto-generated />
using System;
using API.DataLayer.EfCode.DbSetup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.DataLayer.Migrations
{
    [DbContext(typeof(LearnAppDbContext))]
    [Migration("20210902084756_MakeLearningTaskTagRequired")]
    partial class MakeLearningTaskTagRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("API.DataLayer.Entities.Identity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnType("TEXT");

                    b.HasKey("ExamId");

                    b.HasIndex("CourseId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.LearningTask", b =>
                {
                    b.Property<int>("LearningTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DeadlineDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Importance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LearningTaskId");

                    b.HasIndex("StudentId");

                    b.ToTable("LearningTasks");
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.Lecture", b =>
                {
                    b.Property<int>("LectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Topic")
                        .HasColumnType("TEXT");

                    b.HasKey("LectureId");

                    b.HasIndex("CourseId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.LectureLearningTask", b =>
                {
                    b.Property<int>("LearningTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LectureId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.HasKey("LearningTaskId", "LectureId");

                    b.HasIndex("LectureId");

                    b.ToTable("LectureLearningTasks");
                });

            modelBuilder.Entity("API.DataLayer.Entities.StudentRelationships.StudentCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("API.DataLayer.Entities.StudentRelationships.StudentExam", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "ExamId");

                    b.HasIndex("ExamId");

                    b.ToTable("StudentExams");
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.Exam", b =>
                {
                    b.HasOne("API.DataLayer.Entities.Learning.Course", null)
                        .WithMany("Exams")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.LearningTask", b =>
                {
                    b.HasOne("API.DataLayer.Entities.Identity.AppUser", null)
                        .WithMany("LearningTasks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.Lecture", b =>
                {
                    b.HasOne("API.DataLayer.Entities.Learning.Course", null)
                        .WithMany("Lectures")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.LectureLearningTask", b =>
                {
                    b.HasOne("API.DataLayer.Entities.Learning.LearningTask", "LectureTask")
                        .WithMany("LectureLearningTasks")
                        .HasForeignKey("LearningTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.DataLayer.Entities.Learning.Lecture", "Lecture")
                        .WithMany("LectureLearningTasks")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecture");

                    b.Navigation("LectureTask");
                });

            modelBuilder.Entity("API.DataLayer.Entities.StudentRelationships.StudentCourse", b =>
                {
                    b.HasOne("API.DataLayer.Entities.Learning.Course", null)
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.DataLayer.Entities.Identity.AppUser", null)
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.DataLayer.Entities.StudentRelationships.StudentExam", b =>
                {
                    b.HasOne("API.DataLayer.Entities.Learning.Exam", null)
                        .WithMany("StudentExams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.DataLayer.Entities.Identity.AppUser", null)
                        .WithMany("StudentExams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.DataLayer.Entities.Identity.AppUser", b =>
                {
                    b.Navigation("LearningTasks");

                    b.Navigation("StudentCourses");

                    b.Navigation("StudentExams");
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.Course", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("Lectures");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.Exam", b =>
                {
                    b.Navigation("StudentExams");
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.LearningTask", b =>
                {
                    b.Navigation("LectureLearningTasks");
                });

            modelBuilder.Entity("API.DataLayer.Entities.Learning.Lecture", b =>
                {
                    b.Navigation("LectureLearningTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
