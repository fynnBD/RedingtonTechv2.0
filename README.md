
# Redington Technical Test

Hi there! This is a Technical Test project for an interview process I went through. It consists of two parts. 

1st is a ASP.NET API written with c#. It contains two endpoints, POST/Combine and POST/Either. These endpoints take two parameters as parameter queries, does validation on them, and then returns a probability result based on their values. It contains validation and a fairly simple logging system that logs to a file in the local directory. This project contains the base files which you can run locally, but I am currently hosting it on a free azure container that can be accessed by anyone

the 2nd is a fairly simple react client that connects to the azure hosted api, and allows the user to enter the numbers, choose the calculation type and shows the text output.

# My Process

To be honest, its been quite a while since I last created an app from scratch. Usually my day to day job involves me working with a prexisting product that has its own system and structure that is somewhat abstracted from the raw react and ASP.NET libraries. That being said, its was quite fun to remember all the baseline setup of projects that I haven't worked with since I created a new version of my current employers product a few years ago, how often do you get the chance to setup a Program.cs file from scratch huh?

I chose ASP.NET since im pretty familiar with the base structure of a MVC app, it was an interesting challenge to apply SOLID principles to what is a very simple product. Often times I forewent SOLID stuff that I would use in a large system in the persuit of simplicity. I could probably have made some more basic object types to abstract out from, maybe a generic 'APIDataObject' to make IOutput and IInput derive from, but that would have made the solution more complex instead of simpler. 

The react frontend was more complex for me. I lean more towards backend, and my frustration with JavaScript hasnt quite subsided. I chose a simple SPA structure with a seperate service file. I had never hooked into the raw fetch() functions before, since I have always worked with abstracted API systems that were pre-created, so I learned a lot about how finnicky it can be to get an API response to do what I want! I think in hindsight I could have made it more customisable, added a few config files and moved some stuff out into seperate libraries

# How to run

The hosted swagger site can be found [here](https://redingtonapi-ddhnfsftajb8fhg3.canadacentral-01.azurewebsites.net/swagger/index.html)

the website can be found [here](https://red-rock-021d07610.4.azurestaticapps.net/)

to run the API locally, navigate to RedingtonTechv2.0\RedingtonTechv2.0 and run 'dotnet run'. This will start the API listening on port 5197. Chuck a /swagger after that (http://localhost:5197/swagger/index.html) to check out the API!

to run the client locally, navigate to RedingtonTechv2.0\redingtontechv2.0app and run npm dev, it should run the app on your browser!

if you have any problems, please don't hestiate to message me at medacmedac@gmail.com
