import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LearningTask } from 'src/app/_models/learning-task';
import { Lecture } from 'src/app/_models/lecture';


@Component({
  selector: 'app-lecture-item',
  templateUrl: './lecture-item.component.html',
  styleUrls: ['./lecture-item.component.css']
})
export class LectureItemComponent implements OnInit {
  @Input() lecture: Lecture;
  @Input() isEnrolled: boolean = false;
  @Input() learningTaskParent: LearningTask;
  @Input() lectureType: string;
  @Output() removeLecture = new  EventEmitter<number>()
  constructor() { }

  ngOnInit(): void {

  }

}
