export interface LearningTask extends LearningTaskMin {
    lectures: any [];
}

export interface LearningTaskMin {
    tag: string;
    learningTaskId: number;
    studentId: number;
    importance: number;
    completed: boolean;
    deadlineDate: Date;
    completedLecturesCount: number;
    lecturesCount: number; 
}