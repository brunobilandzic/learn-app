import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { LearningTask } from 'src/app/_models/learning-task';
import { LearningTasksService } from 'src/app/_services/learning-tasks.service';
import { SetTaskModalComponent } from './set-task-modal/set-task-modal.component';

@Component({
  selector: 'app-lecture-task-resolve',
  templateUrl: './lecture-task-resolve.component.html',
  styleUrls: ['./lecture-task-resolve.component.css']
})
export class LectureTaskResolveComponent implements OnInit {
  @Input() lectureId: number;
  learningTask: LearningTask;
  isInTask: boolean = false;
  setTaskModalRef?: BsModalRef;
  constructor(
    private learningTasksService: LearningTasksService,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.learningTasksService.shouldComponentsUpdate$
      .subscribe((shouldUpdate) => {
        if(shouldUpdate)
          this.getLearningTask();
      })
    this.getLearningTask();
  }
  setLearningTaskInformation(lt: any) {
    this.isInTask = lt ? true: false;
    this.learningTask = lt;
  }

  getLearningTask() {
    this.learningTasksService.getTaskWithLectrue(this.lectureId)
      .subscribe((lt: any) => {
        
        console.log(this.lectureId, lt);
        this.setLearningTaskInformation(lt);
        if(lt)
          lt.completed = lt.lectures.filter( (l: any) => l.completed == false).length == 0;
      })
  }



  openSetTaskModal(){
    const initialState = {
      lectureId: this.lectureId
    }
    this.setTaskModalRef = this.modalService.show(SetTaskModalComponent, {initialState})
    this.setTaskModalRef.content.title = this.isInTask ? "Move Lecture To Another Task": "Add Lecture To Task";
    this.setTaskModalRef.content.saveBtnText = this.isInTask ? "Move" : "Add";
  }

}
