import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LEARNING_TASK_LECTURES } from 'src/app/_models/help/component-communication';
import { LearningTask } from 'src/app/_models/learning-task';
import { LearningTasksService } from 'src/app/_services/learning-tasks.service';

@Component({
  selector: 'app-learning-task-view',
  templateUrl: './learning-task-view.component.html',
  styleUrls: ['./learning-task-view.component.css']
})
export class LearningTaskViewComponent implements OnInit {
  learningTask: LearningTask;
  public LEARNING_TASK_LECTURES = LEARNING_TASK_LECTURES;
  constructor(
    private route: ActivatedRoute
  ) { 
    
  }

  ngOnInit(): void {
    this.fetchLearningTask();
  }

  fetchLearningTask() {
    this.route.data.subscribe(
      (paramData) => {
        if(paramData) this.learningTask = paramData.learningTask;
      }
    )
  }

}
