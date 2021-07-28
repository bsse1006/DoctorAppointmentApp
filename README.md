Developer Details
Name    : Yasin Sazid
Roll        : BSSE 1006
Project Details
Project    : 7. Doctor Appointment System
Name    : Doctor Appointment Hub
Back End Application
Technology:
Microsoft ASP.NET Core 2.0.0

Port: 5002

Database: MSSQL

OS: win32 x64

IDE: Visual Studio 2019
Front End Application
Technology:
Angular CLI: 12.1.2
Node: 14.15.4
Package Manager: npm 6.14.10

Port: 4200

OS: win32 x64

IDE: Visual Studio Code
Run The Project
Backend:
Open the solution file using Visual Studio 2019 (BackEnd/ServerApp.sln).
Change the connection string in DatabaseContext.cs file (BackEnd/ServerApp/Model/DatabaseContext.cs).
Create migrations using Package Manager Console: Add-Migration defaultSetup
Update database using Package Manager Console: Update-Database
Run the project using Visual Studio 2019

Frontend:
If there exist node_modules and .vs folders in the project directory (FrontEnd), then remove these folders first.
If Angular CLI is not installed, install it first:
npm install -g @angular/cli
Install dependencies: npm install
Run the project using Visual Studio Code: ng serve --open

Default Admin Credentials:
Username    : admin
Password    : admin

Github Links
Back End:
https://github.com/bsse1006/DoctorAppointmentHubBackEnd
Front End:
https://github.com/bsse1006/DoctorAppointmentHubFrontEnd
