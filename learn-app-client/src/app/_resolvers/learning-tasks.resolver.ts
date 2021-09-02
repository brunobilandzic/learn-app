import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { LearningTasksService } from '../_services/learning-tasks.service';

@Injectable({
  providedIn: 'root'
})
export class LearningTasksResolver implements Resolve<any> {
  constructor(private learningTasksService: LearningTasksService) {
    
  }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> {
    let taskId = route.paramMap.get('id') as string;
    return this.learningTasksService.getLearningTask(taskId);
  }
}
