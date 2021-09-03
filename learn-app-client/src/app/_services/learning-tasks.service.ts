import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, ReplaySubject } from 'rxjs';
import { finalize, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import {
  learningTasksSort,
} from '../_models/help/component-communication';
import { IdToId } from '../_models/help/id-to-id';
import { IdsToId } from '../_models/help/ids-to-id';
import { LearningTaskMin } from '../_models/learning-task';

@Injectable({
  providedIn: 'root',
})
export class LearningTasksService {
  baseApiUrl = environment.baseApiUrl;
  learningTasksCache: LearningTaskMin[] = [];
  shouldComponentsUpdate = new ReplaySubject<boolean>(1);
  shouldComponentsUpdate$ = this.shouldComponentsUpdate.asObservable();
  constructor(private http: HttpClient) {}

  getTaskWithLectrue(lectureId: number) {
    return this.http.get(this.baseApiUrl + 'tasks/w/' + lectureId);
  }

  getTasks(taskListOptions?: any) {
    if (this.learningTasksCache.length)
      return of(this.transformTasks(taskListOptions));

    return this.http.get(this.baseApiUrl + 'tasks').pipe(
      map((response: any) => {
        this.learningTasksCache = response;
        return this.transformTasks(taskListOptions);
      })
    );
  }

  getLearningTask(learningTaskId: string) {
    return this.http.get(this.baseApiUrl + 'tasks/' + learningTaskId);
  }

  setLecturesToTask(lectureIdsTaskId: IdsToId) {
    return this.http
      .post(this.baseApiUrl + 'tasks/lectures', lectureIdsTaskId)
      .pipe(
        finalize(() => {
          this.learningTasksCache = [];
          this.shouldComponentsUpdate.next(true);
        })
      );
  }

  toggleCompleteLecture(lectureId: number, learningTaskId: number) {
    let lectureIdLearningTaskId:  IdToId = {
      firstId: lectureId,
      secondId: learningTaskId
    }

    this.http.post(this.baseApiUrl + 'tasks/lecture-completion', lectureIdLearningTaskId)
      .subscribe(() => this.shouldComponentsUpdate.next(true));
  }

  transformTasks(taskListOptions?: any) {
    if (taskListOptions == null) return this.learningTasksCache;
    let transformedTaskList = this.learningTasksCache.slice();
    console.log(transformedTaskList)
    if (taskListOptions.hidePassed)
      transformedTaskList = transformedTaskList.filter(
        (lt) => new Date(new Date(lt.deadlineDate).getTime() +  60 * 60 * 24 * 1000).getTime() >= Date.now()
      );
    
    if(taskListOptions.hideCompleted) {
      transformedTaskList = transformedTaskList.filter(
        (lt) => lt.completed == false
      );
    }
    switch (taskListOptions.sortBy) {
      case learningTasksSort.importance:
        transformedTaskList.sort((a: LearningTaskMin, b: LearningTaskMin) => {
          return a.importance < b.importance ? 1 : -1;
        });
        break;
      case learningTasksSort.deadlineDate: 
        transformedTaskList.sort((a: LearningTaskMin, b: LearningTaskMin) => {
          return a.deadlineDate > b.deadlineDate
            ? 1
            : -1;
        })
    }
    
    return transformedTaskList;
  }
}
