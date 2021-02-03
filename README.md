OOP Teamwork Assignment
Project Description
Design and implement a Work Item Management (WIM) Console Application.
Functional Requirements
Application should support multiple teams. Each team has name, members, and boards.
Member has name, list of work items and activity history.
 Name should be unique in the application
 Name is a string between 5 and 15 symbols.
Board has name, list of work items and activity history.
 Name should be unique in the team
 Name is a string between 5 and 10 symbols.
There are 3 types of work items: bug, story, and feedback.
Bug
Bug has ID, title, description, steps to reproduce, priority, severity, status, assignee, comments, and
history.
 Title is a string between 10 and 50 symbols.
 Description is a string between 10 and 500 symbols.
 Steps to reproduce is a list of strings.
 Priority is one of the following: High, Medium, Low
 Severity is one of the following: Critical, Major, Minor
 Status is one of the following: Active, Fixed
 Assignee is a member from the team.
 Comments is a list of comments (string messages with author).
 History is a list of all changes (string messages) that were done to the bug.
Story
Story has ID, title, description, priority, size, status, assignee, comments, and history.
 Title is a string between 10 and 50 symbols.
 Description is a string between 10 and 500 symbols.
 Priority is one of the following: High, Medium, Low
 Size is one of the following: Large, Medium, Small
 Status is one of the following: NotDone, InProgress, Done
 Assignee is a member from the team.
 Comments is a list of comments (string messages with author).
 History is a list of all changes (string messages) that were done to the story.
Feedback
Feedback has ID, title, description, rating, status, comments, and history.
 Title is a string between 10 and 50 symbols.
 Description is a string between 10 and 500 symbols.
 Rating is an integer.
 Status is one of the following: New, Unscheduled, Scheduled, Done
 Comments is a list of comments (string messages with author).
 History is a list of all changes (string messages) that were done to the feedback.
Note: IDs of work items should be unique in the application i.e. if we have a bug with ID X then
we cannot have Story of Feedback with ID X.
Operations
Application should support the following operations:
 Create a new person
 Show all people
 Show person's activity
 Create a new team
 Show all teams
 Show team's activity
 Add person to team
 Show all team members
 Create a new board in a team
 Show all team boards
 Show board's activity
 Create a new Bug/Story/Feedback in a board
 Change Priority/Severity/Status of a bug
 Change Priority/Size/Status of a story
 Change Rating/Status of a feedback
 Assign/Unassign work item to a person
 Add comment to a work item
 List work items with options:
o List all
o Filter bugs/stories/feedback only
o Filter by status and/or assignee
o Sort by title/priority/severity/size/rating
General Requirements
 Follow the OOP best practices:
o Proper use data encapsulation
o Proper use of inheritance and polymorphism
o Proper use of interfaces and abstract classes
o Proper use of static members
o Proper use enumerations
o Follow the principles of strong cohesion and loose
coupling
 Use LINQ
 Implement proper user input validation and display meaningful user messages
 Implement proper exception handling
 Cover functionality with unit tests (80% code coverage)
 Use Git to keep your source code and for team collaboration
Teamwork Requirements
Refer to the teamwork requirements document found along with the project requirements.
Teamwork defense
Prepare a list of commands to demonstrate how the program works.
