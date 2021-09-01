import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, ReplaySubject } from 'rxjs';
import { finalize, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IdsToId } from '../_models/help/idsToId';
import { LearningTask } from '../_models/learning-task';
import { CoursesService } from './courses.service';

@Injectable({
  providedIn: 'root'
})
export class LearningTasksService {
  baseApiUrl = environment.baseApiUrl;
  learningTasksCache: LearningTask [] = [];
  shouldComponentsUpdate = new ReplaySubject<boolean>(1);
  shouldComponentsUpdate$ = this.shouldComponentsUpdate.asObservable();
  constructor(
    private http: HttpClient
  ) { }


  getTaskWithLectrue(lectureId: number) {
    return this.http.get(this.baseApiUrl + 'tasks/w/' + lectureId);
  }

  getTasks() {
    if(this.learningTasksCache.length)
      return of(this.learningTasksCache);
    
    return this.http.get(this.baseApiUrl + 'tasks')
      .pipe(
        map((response: any) => {
          this.learningTasksCache = response;
          return response;
        })
      )
  }

  setLecturesToTask(lectureIdsTaskId: IdsToId) {
    return this.http.post(this.baseApiUrl + 'tasks/lectures', lectureIdsTaskId)
      .pipe(
        finalize(() => {
          this.learningTasksCache = [];
          this.shouldComponentsUpdate.next(true);
        })
      )
  }
}
