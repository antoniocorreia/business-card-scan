# Business Card Scan


# Introduction 
## Motivation
I'm currently part of the development team of the MCN app at Kuvio, and once I read about this hackathon my first thought was to bring one of my ideas to life.

MCN is a contact manager app for those who want to stay organized with custom contact labels and groups. With that in mind, my idea was to transform the current "business card" approach in a simple take a photo and store the data, so instead of having to input all the data from a piece of paper (sometimes multiple cards) you just have to take a photo and using the Azure Cognitive Service - Form Recognizer, more specifically the pre built business card model all the info you need will be mapped automatically, such as first name, last name, company name, department, phones, emails, etc.

## Implementation
To validate the idea I've created the Business Card Scan app so later I can migrate the feature to the MCN, and to make that process even easier I decided to create the app with the same stack we're using at Kuvio - MAUI Blazor app + .NET 6 Minimal API.

# How to run
I'm using Microsoft Visual Studio Community 2022 - Preview Version 17.2.0 Preview 1.0
to run the MAUI Blazor app that is already pointing to a published testing API https://business-card-scan-api.azurewebsites.net/

You can also publish your own API using the project (just remember to add the secrets for CognitiveServices:endpoint and CognitiveServices:apiKey


# Youtube simulation

[![Youtube simulation](http://img.youtube.com/vi/frpQ1pH9Hfk/0.jpg)](http://www.youtube.com/watch?v=frpQ1pH9Hfk "Business Card Scan")

# Contributing
Feel free to open a new issue and submit a pull request with any new feature or adjustment. 
