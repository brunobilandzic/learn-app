import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseNavigation } from 'src/app/_models/course-navigation';
import { Exam } from 'src/app/_models/exam';
import { Lecture } from 'src/app/_models/lecture';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-course-view',
  templateUrl: './course-view.component.html',
  styleUrls: ['./course-view.component.css'],
})
export class CourseViewComponent implements OnInit {
  mode: string | null;
  courseId: string | null;
  courseNavigation: CourseNavigation;
  constructor(
    private coursesService: CoursesService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.queryParamMap.subscribe((params) => {
      this.mode = params.get('mode');
    });

    this.route.paramMap.subscribe((params) => {
      this.courseId = params.get('id');
      this.coursesService.getCourseNavigation(this.courseId as string)
        .subscribe((courseNavigation) => {
          this.courseNavigation = courseNavigation;
        })

    });
    
  }
}
