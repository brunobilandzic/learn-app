import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import {
  learningTaskListOptions,
  learningTasksSort,
} from 'src/app/_models/help/component-communication';
import { LearningTaskMin } from 'src/app/_models/learning-task';
import { LearningTasksService } from 'src/app/_services/learning-tasks.service';

@Component({
  selector: 'app-learning-tasks-list',
  templateUrl: './learning-tasks-list.component.html',
  styleUrls: ['./learning-tasks-list.component.css'],
})
export class LearningTasksListComponent implements OnInit {
  learningTasks: LearningTaskMin[];
  listOptions =  {...learningTaskListOptions};

  sortByOptions: string[] = Object.values(learningTasksSort);
  constructor(private learningTaskService: LearningTasksService) {}

  ngOnInit(): void {
    this.getLearningTasks();
    this.learningTaskService.shouldComponentsUpdate$.subscribe(
      (shouldUpdate) => {
        if (shouldUpdate) this.getLearningTasks();
      }
    );
  }

  getLearningTasks() {
    this.learningTaskService
      .getTasks(this.listOptions)
      .subscribe((tasks: LearningTaskMin[]) => {
        this.learningTasks = tasks
      });
  }

  onOptionsChange(e: any) {
    
    if(e.target.type == 'checkbox') {
      this.listOptions[e.target.name] = !this.listOptions[e.target.name];
      console.log(this.listOptions)
    } else {
      this.listOptions[e.target.name] = e.target.value;
    }
    this.getLearningTasks();
  }
}
