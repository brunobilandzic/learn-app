export interface LearningTask {
    tag: string;
    learningTaskId: number;
    studentId: number;
    importance: number;
    completed: boolean;
    deadlineDate: Date;
    lectures: any [];
}