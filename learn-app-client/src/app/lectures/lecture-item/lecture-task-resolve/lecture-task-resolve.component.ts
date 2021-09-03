import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import {
  COURSE_LECTURES,
  LEARNING_TASK_LECTURES,
} from 'src/app/_models/help/component-communication';
import { LearningTask } from 'src/app/_models/learning-task';
import { LectureLearningTask } from 'src/app/_models/lecture-learning-task';
import { LearningTasksService } from 'src/app/_services/learning-tasks.service';
import { SetTaskModalComponent } from './set-task-modal/set-task-modal.component';

@Component({
  selector: 'app-lecture-task-resolve',
  templateUrl: './lecture-task-resolve.component.html',
  styleUrls: ['./lecture-task-resolve.component.css'],
})
export class LectureTaskResolveComponent implements OnInit {
  @Input() lectureId: number;
  learningTask: LearningTask;
  @Input() learningTaskParent: LearningTask;
  lectureLearningTask: LectureLearningTask;
  isInTask: boolean = false;
  setTaskModalRef?: BsModalRef;
  @Input() lectureType: string;
  @Input() removeLecture: EventEmitter<number>;
  LEARNING_TASK_LECTURES = LEARNING_TASK_LECTURES;
  COURSE_LECTURES = COURSE_LECTURES;
  constructor(
    private learningTasksService: LearningTasksService,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.learningTasksService.shouldComponentsUpdate$.subscribe(
      (shouldUpdate) => {
        if (shouldUpdate && this.lectureType == COURSE_LECTURES) {
          this.resolveNeededInformation();
        }
      }
    );
    this.resolveNeededInformation();
  }
  setLearningTaskInformation(lt: any) {
    this.isInTask = lt ? true : false;
    this.learningTask = lt;
  }

  resolveNeededInformation() {
    if (this.lectureType == COURSE_LECTURES) {
      this.learningTasksService
        .getTaskWithLectrue(this.lectureId)
        .subscribe((lt: any) => {
          this.setLearningTaskInformation(lt);
        });
    } else if (this.lectureType == LEARNING_TASK_LECTURES) {
      this.isInTask = true;
      this.lectureLearningTask = this.learningTaskParent.lectures.filter(
        (l: LectureLearningTask) => l.lectureId == this.lectureId
      )[0];
    }
  }
  setLectureLearningTaskInformation(llt: any) {
    this.lectureLearningTask = llt;
  }

  lectureLearningTaskCompletionChange(e: any) {
    this.lectureLearningTask.completed = !this.lectureLearningTask.completed;
    this.learningTasksService.toggleCompleteLecture(
      e.target.name as number,
      this.learningTaskParent.learningTaskId
    );
  }

  getCheckboxLabel() {
    return this.lectureLearningTask?.completed ? 'Completed' : 'Not completed';
  }

  openSetTaskModal() {
    const initialState = {
      lectureId: this.lectureId,
      removeLecture : this.removeLecture
    };
    this.setTaskModalRef = this.modalService.show(SetTaskModalComponent, {
      initialState,
    });
    this.setTaskModalRef.content.title = this.isInTask
      ? 'Move Lecture To Another Task'
      : 'Add Lecture To Task';
    this.setTaskModalRef.content.saveBtnText = this.isInTask ? 'Move' : 'Add';
  }
}
