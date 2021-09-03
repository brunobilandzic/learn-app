import { Component, Input, OnInit } from '@angular/core';
import { LearningTask } from 'src/app/_models/learning-task';
import { Lecture } from 'src/app/_models/lecture';

@Component({
  selector: 'app-lectures-list',
  templateUrl: './lectures-list.component.html',
  styleUrls: ['./lectures-list.component.css']
})
export class LecturesListComponent implements OnInit {
  @Input() lectures: Lecture [];
  @Input() isEnrolled: boolean = false;
  @Input() lecturesType: string;
  @Input() learningTaskParent: LearningTask;
  constructor() { 
    
  }

  ngOnInit(): void {
    if(this.learningTaskParent != undefined) {
      console.log(this.learningTaskParent)
      this.lectures = this.learningTaskParent.lectures;
    }
  }

  hideLectureFromList(lectureId: number) {
    this.lectures = this.lectures.filter(l => l.lectureId != lectureId);
  }

}
