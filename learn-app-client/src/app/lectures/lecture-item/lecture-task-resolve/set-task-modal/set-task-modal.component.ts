import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { IdsToId } from 'src/app/_models/help/idsToId';
import { LearningTask } from 'src/app/_models/learning-task';
import { LearningTasksService } from 'src/app/_services/learning-tasks.service';

@Component({
  selector: 'app-set-task-modal',
  templateUrl: './set-task-modal.component.html',
  styleUrls: ['./set-task-modal.component.css'],
})
export class SetTaskModalComponent implements OnInit {
  lectureId: number;
  title: string;
  saveBtnText: string;
  learningTasks: LearningTask[];
  selectedLearningTaskId: number = 0;
  constructor(
    public bsModalRef: BsModalRef,
    private learningTasksService: LearningTasksService
  ) {}

  ngOnInit(): void {
    this.getLearningTasks();
  }

  getLearningTasks() {
    this.learningTasksService.getTasks().subscribe((learningTasks: any) => {
      this.learningTasks = learningTasks.filter(
        (lt: any) =>
          lt.lectures.filter((l: any) => l.lectureId == this.lectureId)
            .length == 0
      );
      console.log(this.learningTasks)
    });
  }

  onSave() {
      let lectureIdsToId: IdsToId = {
        id: this.selectedLearningTaskId,
        ids: [this.lectureId]
      };
      this.learningTasksService.setLecturesToTask(lectureIdsToId)
        .subscribe(() => {
          this.bsModalRef.hide();
          
        })
  }
}
