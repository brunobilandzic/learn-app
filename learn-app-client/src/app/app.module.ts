import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { ToastrModule } from 'ngx-toastr';
import {  FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ErrorsInterceptor } from './_interceptors/errors.interceptor';
import { NgxSpinnerModule } from "ngx-spinner";
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { RegisterComponent } from './register/register.component';
import { TextInputComponent } from './_inputs/text-input/text-input.component';
import { CommonModule } from '@angular/common';
import { CoursesComponent } from './courses/courses-panel/courses.component';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { CoursesListComponent } from './courses/courses-list/courses-list.component';
import { CourseLinkComponent } from './courses/courses-list/course-link/course-link.component';
import { CourseViewComponent } from './courses/course-view/course-view.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    RegisterComponent,
    TextInputComponent,
    CoursesComponent,
    CoursesListComponent,
    CourseLinkComponent,
    CourseViewComponent
  ],
  imports: [
    ToastrModule.forRoot(
      {positionClass: 'toast-bottom-right'}
    ),
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    NgxSpinnerModule,
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    TabsModule.forRoot()
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ErrorsInterceptor, multi: true}
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
