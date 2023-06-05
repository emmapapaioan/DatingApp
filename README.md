<h1>Dating App <em><sub><sup>  *Under construction</sup></sub></em></h1>

[![Watch the video](https://user-images.githubusercontent.com/108992250/220931788-8a115f68-4d0a-4e15-9285-8bb65183f8ab.mp4)](https://user-images.githubusercontent.com/108992250/220931788-8a115f68-4d0a-4e15-9285-8bb65183f8ab.mp4)

Welcome to the DatingApp project! This is a web application for dating that allows users to create profiles, search for matches, and interact with each other. This project consists of two main parts: the API and the client-side application.

## Getting Started
To get started, clone this repository to your local machine using the following command:
`git clone https://github.com/emmapapaioan/DatingApp.git`

## Prerequisites
Before running the application, make sure you have the following software installed on your machine:

- .NET Core SDK
- Node.js and npm
- Angular CLI
- Visual Studio or Visual Studio Code (optional)

## Running the API
To run the API, navigate to the API folder from the terminal and run the following command: `dotnet run`.

This will start the API server and make it available at https://localhost:5001.

## Running the client-side application
To run the client-side application, navigate to the client folder from the terminal and perform the following steps: 

1. Run `npm install`. This command is needed only the first time you're setting up the project, as it downloads and installs the necessary node modules as per the project's `package.json` file. If you encounter issues, you may optionally use `npm install --force`, but do so with caution as it can potentially generate an incorrect dependency tree.

2. Run `ng serve` to start the development server.

Once these steps are completed, the application should be available at https://localhost:4200.

## Technologies Used
This project was built using the following technologies:
- Angular 15.1.5
- Bootstrap 5.2.3
- Font Awesome
- ngx-bootstrap
- RxJS
- TypeScript
- HTML5 and CSS3
- C#

## Features

### Authentication
The application includes authentication functionality using JSON Web Tokens (JWT). Users can create an account and login to access the main features of the app.

### User Profiles*
Users can create profiles that include their basic information, photos, and interests. They can also edit their profiles and upload new photos.

### Matching*
The application includes a matching feature that allows users to search for potential matches based on their interests and location. Users can view other users' profiles and choose to like or dislike them.

### Messaging*
Users can communicate with each other using a messaging system. They can send and receive messages from their matches and view their conversation history.

_*Under construction_

*This project was implemented as I was practising on how to use the framework Angular and the programming language C#. Video Source: https://www.udemy.com/course/build-an-app-with-aspnet-core-and-angular-from-scratch/learn/lecture/22400360#reviews by Neil Cummings.*
