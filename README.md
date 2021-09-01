# README #

This README would normally document whatever steps are necessary to get your application up and running.

### What is this repository for? ###

* App for tracking learning tasks

### Application properties ###
* Only one role - student ( roles not implemented ), no user to user interactions
* Entities:
    * AppUser
    * Course
    * Lecture
    * Exam
    * LearningTask
* Relationships:
First Entity    | Second Entity | Cardinality | Realationship Table
----------------|---------------|-------------|--------------------
AppUser         | Course        | (0,n)-(0,n) | StudentCourse
AppUser         | Exam          | (0,n)-(0,n) | StudentExam
AppUser         | LearningTask  | (1,1)-(0,n) | -
Course          | Lecture       | (1,1)-(0,n) | -
Course          | Exam          | (1,1)-(0,n) | -
LearningTask    | Lecture       | (0,n)-(0,n) | LectureLearningTask


    

### How do I get set up? ###

* Porject is made with dotnet CLI, and because of some .Net framework versioning cannot be opened in Visual Studio
* Open project folder with Visual Studio Code
* cd API; dotnet watch run;
* cd learn-app-client; ng serve;
* for migrations add : cd API; dotnet ef migrations add "MigrationTagName"
* for database drop: cd API; dotnet ef database drop;
* database seeded if empty on dotnet watch run;

* login
    * username: neal
    * password: password