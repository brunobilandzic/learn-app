import { Component, Input, OnInit } from '@angular/core';
import { Course } from 'src/app/_models/course';

@Component({
  selector: 'app-course-link',
  templateUrl: './course-link.component.html',
  styleUrls: ['./course-link.component.css']
})
export class CourseLinkComponent implements OnInit {
  @Input() course: Course;
  @Input() mode: string;
  constructor() { }

  ngOnInit(): void {
  }

}
