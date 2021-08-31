import { Component, Input, OnInit } from '@angular/core';
import { Course } from 'src/app/_models/course';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.css']
})
export class CoursesListComponent implements OnInit {
  @Input() mode: string;
  courses: Course [];

  constructor(
    private coursesService: CoursesService
  ) { }
  
  ngOnInit(): void {
    this.coursesService.getCourses(this.mode)
      .subscribe((courses: Course[]) => {
        this.courses = courses;
      })
  }

}
