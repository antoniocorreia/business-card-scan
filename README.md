# Business Card Scan


# Introduction 
## Motivation
I'm currently part of the development team at Kuvio Creative, and we've recently been working on a web/MAUI Blazor hybrid app called My Contact Network. So once I read about this hackathon, my first thought was to finally bring to life one of my favorite ideas for this app.

My Contact Network is a native mobile & web contact management app for those who want to keep their contacts' information always up to date. To connect with or invite someone to the platform, you simply type in their email address or phone number, and if they have you in their contacts list as well, you'll automatically swap real-time contact info from then on, granting you an always-current contact list.

With that in mind, my idea was to use the Azure Cognitive Services Form Recognizer library to upgrade the typical "business card swap" that occurs around the conference table. By simply taking a photo of the business card you just received, all the info from the card will be mapped automatically to a new contact in My Contact Network, such as first name, last name, company name, department, phones, emails, etc. This will kick off the auto-connection process in the app as well, causing the new "virtual" business cards to be digitally swapped instantaneously.

## Implementation
To validate the idea I've created the Business Card Scan app so I can later migrate the feature to My Contact Network. To make the migration process even easier, I decided to create the app with exactly the same stack we're using for My Contact Network: A MAUI Blazor app + .NET 6 Minimal API.

The app is pretty clean and straightforward -- there is a single page to take a photo using MAUI Essentials native functionality on either iOS or Android, and then upload it to the API, where it's processed and all the info extracted is returned and displayed.

# How to run
I'm using Microsoft Visual Studio Community 2022 - Preview Version 17.2.0 Preview 1.0
to run the MAUI Blazor app that is already pointing to a published testing API https://business-card-scan-api.azurewebsites.net/

You can also publish your own API using the project (just remember to add the secrets for CognitiveServices:endpoint and CognitiveServices:apiKey


# Youtube simulation

[![Youtube simulation](http://img.youtube.com/vi/frpQ1pH9Hfk/0.jpg)](http://www.youtube.com/watch?v=frpQ1pH9Hfk "Business Card Scan")

# Contributing
Feel free to open a new issue and submit a pull request with any new feature or adjustment. 
