import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseNavigation } from 'src/app/_models/course-navigation';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-course-view',
  templateUrl: './course-view.component.html',
  styleUrls: ['./course-view.component.css'],
})
export class CourseViewComponent implements OnInit {
  courseNavigation: CourseNavigation;
  isEnrolled: boolean = false;
  studentCourse: any;

  public ENROLLED_STATE_TEXT = 'Enrolled ☑';
  public NOT_ENROLLED_STATE_TEXT = 'Not Enrolled ✖';
  ENROLL_ACTION_TEXT = 'Enroll ?';
  UNROLL_ACTION_TEXT = 'Unroll ?';

  @ViewChild('enrolled') enrolledBtn: any;
  @ViewChild('notEnrolled') notEnrolledBtn: any;
  constructor(
    private route: ActivatedRoute,
    private coursesService: CoursesService
  ) {}

  ngOnInit(): void {
    this.fetchResolved();
  }

  fetchResolved() {
    this.route.data.subscribe((resolvedData: any) => {
      if (resolvedData.courseInfoResolved == null) return;
      this.courseNavigation = resolvedData.courseInfoResolved.course;
      this.setEnrolledInformation(
        resolvedData.courseInfoResolved.studentCourse
      );
    });
  }

  onMouseEnterEnrolled(e: any) {
    console.log(this.enrolledBtn);
    this.enrolledBtn.nativeElement.classList.remove('btn-outline-dark');
    this.enrolledBtn.nativeElement.classList.add('btn-danger');
    this.enrolledBtn.nativeElement.innerText = this.UNROLL_ACTION_TEXT;
  }

  onMouseLeaveEnrolled(e: any) {
    this.enrolledBtn.nativeElement.classList.remove('btn-danger');
    this.enrolledBtn.nativeElement.classList.add('btn-outline-dark');
    this.enrolledBtn.nativeElement.innerText = this.ENROLLED_STATE_TEXT;
  }
  onMouseEnterNotEnrolled(e: any) {
    console.log(this.notEnrolledBtn);
    this.notEnrolledBtn.nativeElement.classList.remove('btn-outline-dark');
    this.notEnrolledBtn.nativeElement.classList.add('btn-success');
    this.notEnrolledBtn.nativeElement.innerText = this.ENROLL_ACTION_TEXT;
  }

  onMouseLeaveNotEnrolled(e: any) {
    console.log(this.notEnrolledBtn);
    this.notEnrolledBtn.nativeElement.classList.remove('btn-success');
    this.notEnrolledBtn.nativeElement.classList.add('btn-outline-dark');
    this.notEnrolledBtn.nativeElement.innerText = this.NOT_ENROLLED_STATE_TEXT;
  }

  setEnrolledInformation(studentCourse: any) {
    this.isEnrolled = studentCourse ? true : false;
    this.studentCourse = studentCourse;
  }
  fetchStudentCourse(courseId: string) {
    this.coursesService.getStudentCourse(courseId).subscribe((sc) => {
      console.log(sc);
      this.setEnrolledInformation(sc);
    });
  }

  onUnroll() {
    if (this.courseNavigation == undefined) return;
    if (
      window.confirm(
        `Dou you want to unroll from this course? 
        By doing this all this courses lectures will be removed from learning tasks, and you will unassing from all its exams.`
      ) == false
    )
      return;
    this.coursesService
      .unrollFromCourse(this.courseNavigation.courseId.toString())
      .subscribe(() => {
        this.fetchStudentCourse(this.courseNavigation.courseId.toString());
      });
  }
  onEnroll() {
    if (this.courseNavigation == undefined) return;
    if (
      window.confirm(
        `Dou you want to enroll in this course? 
        By doing this you will be assigned to all its exams.`
      ) == false
    )
      return;
    this.coursesService
      .erollInCourse(this.courseNavigation.courseId.toString())
      .subscribe(() => {
        this.fetchStudentCourse(this.courseNavigation.courseId.toString());
      });
  }
}
