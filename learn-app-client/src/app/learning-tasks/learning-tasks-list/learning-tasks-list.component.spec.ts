import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningTasksListComponent } from './learning-tasks-list.component';

describe('LearningTasksListComponent', () => {
  let component: LearningTasksListComponent;
  let fixture: ComponentFixture<LearningTasksListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningTasksListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningTasksListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
