import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseViewComponent } from './courses/course-view/course-view.component';
import { CoursesComponent } from './courses/courses-panel/courses.component';

import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';
import { GuestGuard } from './_guards/guest.guard';
import { CourseResolver } from './_resolvers/course.resolver';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'courses',
        component: CoursesComponent
      },
      {
        path: 'courses/:id',
        component: CourseViewComponent,
        resolve: {
          courseInfoResolved: CourseResolver
        }
      }
    ],
  },
  {
    path: '',
    component: RegisterComponent,
    canActivate: [GuestGuard],
    children: [
      {
        path: 'register',
        component: RegisterComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
