export const ACTION_SUCCESS = 1;
export const ACTION_FAILURE = 0;
export const ALL_COURSES = 'ALL_COURSES';
export const MY_COURSES = 'MY_COURSES';
export const COURSE_LECTURES = 'COURSE_LECTURES';
export const LEARNING_TASK_LECTURES = 'LEARNING_TASK_LECTURES';
export const learningTasksSort = {
  deadlineDate: 'Deadline Date',
  importance: 'Importance'
};
export const learningTaskListOptions: {[key: string]: any}  = {
  hidePassed :false,
  hideCompleted :false,
  sortBy :learningTasksSort.deadlineDate
}
