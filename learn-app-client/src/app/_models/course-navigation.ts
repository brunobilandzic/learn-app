import { Course } from "./course";
import { Exam } from "./exam";
import { Lecture } from "./lecture";

export interface CourseNavigation extends Course {
    lectures: Lecture[];
    exams: Exam[]
}