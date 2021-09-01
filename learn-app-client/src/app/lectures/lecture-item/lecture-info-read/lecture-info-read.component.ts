import { Component, Input, OnInit } from '@angular/core';
import { Lecture } from 'src/app/_models/lecture';

@Component({
  selector: 'app-lecture-info-read',
  templateUrl: './lecture-info-read.component.html',
  styleUrls: ['./lecture-info-read.component.css']
})
export class LectureInfoReadComponent implements OnInit {
  @Input() lecture: Lecture;
  constructor() { }

  ngOnInit(): void {
  }

}
