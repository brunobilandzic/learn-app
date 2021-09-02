import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-task-card-icon',
  templateUrl: './task-card-icon.component.html',
  styleUrls: ['./task-card-icon.component.css']
})
export class TaskCardIconComponent implements OnInit {
  @Input() iconType:  string; 
  @Input() daysDiff: number;
  constructor() { }

  ngOnInit(): void {
    console.log(this.iconType)
  }




  generateIconContent() {
    switch(this.iconType) {
      case "deadline-passed":
        return "❗ " + -this.daysDiff + " day"+ (this.daysDiff != -1 ? "s": "") + " past due"
      case "deadline-warning":
        return "🏁 " + this.daysDiff + " day"+ (this.daysDiff != 1 ? "s": "") + " until deadline";
      case "deadline-comfy":
        return "🚀 "  + this.daysDiff + " day"+ (this.daysDiff != 1 ? "s": "") +  " until deadline";
      case "completed":
        return "";
      default:
        return "";
    }
  }
}
