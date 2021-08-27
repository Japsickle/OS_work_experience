# Introduction 

With remote working we have seen a rise in the number of meetings being held across the organisation as these are replacing informal chats and desk "walk ups". It is not uncommon for senior members of the department to have their calendars filled with meetings all day.

Trying to book meetings with multiple people is becoming more difficult and time consuming as it is difficult to easily identify a possible time slot. As such as tool that automates this process will save a significant amount of time and effort.

This tool is first step in a wider project to help us better manage peoples availability for flexible working, annual leave and training.

## Scheduling Assistant

The scheduling assistant will be a simple console app tool that will take the following information:

1. The names of the people who I want to be at my meeting.
2. The earliest date and time at which the meeting could start.
3. The latest date and time at which the meeting could end.
4. The length I wish my meeting to be.

The assistant will take this data, review everyones calendar and display the first available time slot for the meeting during standard office hours.

## Starter Solution

We have provided a starter solution that is in this repo. It is setup to deal with the authentication part of this program for you. It will give you the ability to get an authenticated "client" (this will make more sense in due course) that will let you get everything you need. We have done this in order to take some of the complexity of dealing with external API's away from you. 

The Solution has two projects, the scheduling assistant and the meeting availability checker. The role of the scheduling assistant is to collect the user information and display the results. The role of the MeetingAvailabilityChecker is to query the graph api to get the availability data and to return it in a useful format for the scheduling assistant to display.

For this you will need to use the Authenticator class to get a authenticated client. You should not need to change that class, just use its available method. Sam and Tom will help you understand what the client is and how to use it when we get to that point.

## Things to be aware of

### Authentication

We have taken care of authentication for you. The first time you run the solution you will be presented with a login box in the browser (it should pop up). You will need to sign in using your normal OS user name and password. You will then be asked to provide consent for an application to use your details. You will need to provide consent. On future run throughs you may still have to log in but you shouldn't be asked for that consent again.

### Working Process

We expect you to initially work on this together as a team in the mob. Once you have got the basics working we may look at giving you parallel features to work on. Please do not progress this at home or outside of OS working hours. It is acceptable to work on this solo during any downtime you have between 09.30 and 17.00. If you do this it is your responsability to fully bring the other person up to date with what has happened and to be prepared to make any changes they may suggest.

[Here](https://workflowy.com/#/da20929b318b) are a list of user stories. They have broken down the steps we believe are needed to complete this project in the order that we think makes the most sense. Please complete them one at a time and speak to us if you feel the order is wrong. Please don't be afraid to ask questions and note that many of them have further sub-bullets with more information. A user story is done when the statement that makes up the title is true.

When a user story has been completed please submit a PR to Tom and Sam to review. To do this you will need to do your developement on a branch other than main/master. Whilst waiting for us to review your PR feel free to start planning and reasearching what you need for the next story but do not start coding it until the PR has been completed.

The user stories can be found under the project #SchedulingAssistant in the projects section of [Workflowy](https://workflowy.com/#/e2faaa604915). The user story you are working on should be moved from there to the Working On section under Currently near the top, tagged with your names and the tag #SchedulingAssistant. During standups you will be expected to update the team with how you are getting on with that piece of work.

### Demo

Towards the end of your last week we have a demo scheduled as a team. We are expecting you to demo this project in full to the team and any other invited guests. You are likely to be asked questions and will be expected to provide a short presentation and a code demo. We will assist you in preparing this, don't worry about it but bear it in mind as you work through the user stories. You may also be asked to give less formal, smaller demos before then.