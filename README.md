# Brew Crew

## Project Description
Brew Crew is a beer management system for brewery owners. It enables brewery managers to add, edit, and delete beers specific to their brewery. Additionally, customers can access an IOS app and view beers at a specified location, place orders, create an account, and view order history.

## Technlologies Used

* ASP.net
* Entity Framework Core
* PostgreSQL
* xUnit Testing
* C#
* Swift 5.2
* HTML
* CSS

## Features
* Add, Edit, Delete Beers
* View Brewery order history
* View Customer order history
* Browse beers by brewery
* Order single or multiple beers

### Feature Roll-Out:

* Beer sensor client that obtains the amount of beer left in a keg. This will communicate with the postgreSQL DB through the API
* In-depth data analysis for brewery managers. This will give the managers the option to generate charts and other visual tools to be able to view beer sells by type, data(season), alcohol content, bitterness, and name
* Archive beers. If an order has been placed by a customer for a particular beer, that beer cannot be deleted. I will add archive functionality which brewery managers can add/remove beer listings. This is also helpful for seasonal beers

## Getting Started
Note: to run the IOS application, you must have macOS 10.14 or later and xcode 11 installed. Most of the code is not swift 5.2 specific so if you decide to use an earlier version of swift only minor changes, if any at all, would need to be changed. Therefore, it is possible to run on earlier versions of macOS.

Run the API: in a terminal window run the follwoing commands<br>
1. clone the directory: <br>
`git clone https://github.com/201019-UiPath/FoleyBrian-Project1.git` <br>
2. navigate to the API Folder <br>
`cd FoleyBrian-Project1/API` <br>
3. run the following dotnet command. This will run the api on your local server port 47720<br>
`dotnet run --project BrewCrewAPI` <br>
4. minimize the terminal window

Run the ManagerUI Web Application: in a seperate terminal window run the following commands
2. navigate to the ManagerUI Folder <br>
`cd FoleyBrian-Project1/UI/ManagerUI` <br>
3. run the following dotnet command. This will run the web application on your local server port 5001<br>
`dotnet run --project BrewCrewAPI` <br>
4. minimize the terminal window

Navigate to the manager UI by opening up a browser of your choice and input the following url:<br>
`localhost:5001`
You should see the following screen: <br>

## Usage

## Contributors
Special thanks to <a href='https://github.com/201019-UiPath/JenningsJacob-Project1'>Jacob Jennings</a> for help with routing, json serialization, and http requests

## License
