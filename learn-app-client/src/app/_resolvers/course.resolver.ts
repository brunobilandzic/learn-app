import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { forkJoin, Observable, of } from 'rxjs';
import { CoursesService } from '../_services/courses.service';

@Injectable({
  providedIn: 'root'
})
export class CourseResolver implements Resolve<any> {

  constructor(
    private courseService: CoursesService
  ) {}
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> {
    let courseId = route.paramMap.get('id') as string;
    return forkJoin(
      {
        course: this.courseService.getCourseNavigation(courseId),
        studentCourse: this.courseService.getStudentCourse(courseId)
      }
    )
  }
}
