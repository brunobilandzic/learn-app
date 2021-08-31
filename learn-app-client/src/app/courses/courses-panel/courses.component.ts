import { Component, OnInit } from '@angular/core';
import { ALL_COURSES, MY_COURSES } from 'src/app/_models/help/component-communication';
@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {
  public ALL_COURSES = ALL_COURSES;
  public MY_COURSES = MY_COURSES;
  constructor() { }

  ngOnInit(): void {
  }

}
