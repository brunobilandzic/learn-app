import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Course } from '../_models/course';
import {
  ALL_COURSES,
  MY_COURSES,
} from '../_models/help/component-communication';

@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  baseApiUrl = environment.baseApiUrl;
  allCourses: Course[] = [];
  myCourses: Course[] = [];
  courseNavigation = new Map();
  
  constructor(private http: HttpClient) {}

  getCourses(mode: string) {
    switch (mode) {
      case ALL_COURSES:
        return this.getAllCourses();
      case MY_COURSES:
        return this.getMyCourses();
      default:
        return of([]);
    }
  }

  getAllCourses() {
    if (this.allCourses.length) return of(this.allCourses);
    return this.http.get(this.baseApiUrl + 'courses').pipe(
      map((response: any) => {
        this.allCourses = response;
        return this.allCourses;
      })
    );
  }

  getMyCourses() {
    if (this.myCourses.length) return of(this.myCourses);
    return this.http.get(this.baseApiUrl + 'courses/student').pipe(
      map((response: any) => {
        this.myCourses = response;
        return this.myCourses;
      })
    );
  }

  getCourseNavigation(courseId: string) {
    let key = courseId;
    let coursNavigationCached = this.courseNavigation.get(key);
    if(coursNavigationCached)
      return of(coursNavigationCached);
    
    return this.http.get(this.baseApiUrl + 'courses/' + courseId)
      .pipe(
        map((response: any) => {
          this.courseNavigation.set(key, response);
          return response;
        })
      )
  }

  getStudentCourse(courseId: string) {
    return this.http.get(this.baseApiUrl + 'courses/student/' + courseId);
  }

  erollInCourse(courseId: string) {
    return this.http.post(this.baseApiUrl + 'courses/enroll/' + courseId, {});
  }

  unrollFromCourse(courseId: string) {
    return this.http.post(this.baseApiUrl + 'courses/unroll/' + courseId, {});
  }

}
