import { Component, Input, OnInit } from '@angular/core';
import { Lecture } from 'src/app/_models/lecture';

@Component({
  selector: 'app-lecture-item',
  templateUrl: './lecture-item.component.html',
  styleUrls: ['./lecture-item.component.css']
})
export class LectureItemComponent implements OnInit {
  @Input() lecture: Lecture;
  @Input() isEnrolled: boolean = false;
  constructor() { }

  ngOnInit(): void {

  }

}
