import { Component, Input, OnInit } from '@angular/core';
import { getDaysDiff } from 'src/app/_helpers/date';
import { LearningTaskMin } from 'src/app/_models/learning-task';

@Component({
  selector: 'app-learning-task-card',
  templateUrl: './learning-task-card.component.html',
  styleUrls: ['./learning-task-card.component.css'],
})
export class LearningTaskCardComponent implements OnInit {
  @Input() learningTask: LearningTaskMin;
  constructor() {}

  ngOnInit(): void {}

  callGetDaysDiff() {
    return getDaysDiff(this.learningTask.deadlineDate);
  }
  dateClass() {
    if (this.learningTask.completed) return 'completed';
    let daysDiff = getDaysDiff(this.learningTask.deadlineDate);

    if (daysDiff < 0) return 'deadline-passed';
    if (daysDiff < 5) return 'deadline-warning';
    return "deadline-comfy";
  }

  getCheckMark() {
    if(this.learningTask.lecturesCount - this.learningTask.completedLecturesCount == 0 && this.learningTask.lecturesCount > 0) return "✔";
    return ""; 
  }
}
