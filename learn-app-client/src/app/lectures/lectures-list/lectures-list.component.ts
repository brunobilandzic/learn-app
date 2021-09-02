import { Component, Input, OnInit } from '@angular/core';
import { Lecture } from 'src/app/_models/lecture';

@Component({
  selector: 'app-lectures-list',
  templateUrl: './lectures-list.component.html',
  styleUrls: ['./lectures-list.component.css']
})
export class LecturesListComponent implements OnInit {
  @Input() lectures: Lecture [];
  @Input() isEnrolled: boolean = false;
  @Input() lecturesType: string;
  constructor() { }

  ngOnInit(): void {
    console.log(this.lecturesType)
  }

}
