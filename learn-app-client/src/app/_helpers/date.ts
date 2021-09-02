export function getDaysDiff(taskDedalineDateString: Date) {
    let nowDate = Date.now();
    let taskDeadline = new Date(taskDedalineDateString + 'z').getTime();

    let dateDiff =  taskDeadline - nowDate;
    let daysDiff = dateDiff / 1000 / 60 / 60 / 24;
    daysDiff = Math.round(daysDiff);
    return daysDiff;
  }