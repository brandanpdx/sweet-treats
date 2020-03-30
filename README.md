# Epicodus Independent Project - March 27, 2020

### Created by: Brandan Sayarath

## Description

This is the Epicodus independent end-of-week assignment for Friday, March 27, 2020.  The purpose of this assignment is to create an MVC web application to help manage a shop that sells sweet and savory treats. The application wiil have user authentication. A user will be able to log in and log out. Only logged in users will have create, update and delete functionality. All users will be able to have read functionality.

## Behavior Driven Development Specifications

| Specification             | Input 	|     Output      |
|-------------------------	|-------	|----------------	|
|When user visits '/' root route, display splash page with link to '/treats' and '/flavors' | user visits '/' route | display home|
| When user visits '/treats' display list of all treats, each with 'view detail' link, and 'add new treat' button | user visits '/treats' | display list of treats, and 'Add new treat' button|
| When user clicks 'Add new treat' button, redirect to treat form | clicks 'add new treat' | redirect to '/treats/create'|
| When user visits '/treats/create' show new treats form with field for "treat Name" and "treat Speciality" | user visits '/treats/create' | show treat form |
| When user clicks submit on treat form, add new treat to List and redirect to '/treats' | clicks submit | Add new treat to List, redirect to '/treats' |
| When user visits '/treats/{id}', they will see the details of the treat | user visits treat page | show treat info |
| When user visits '/flavors' display list of all flavors, each with 'view detail' link, and 'add new flavor' button | user visits '/flavors' | display list of flavors, and 'Add new flavor' button|
| When user clicks 'Add new flavor' button, redirect to flavor form | clicks 'add new flavor' | redirect to '/flavor/create'|
| When user visits '/flavor/create' show new flavor form with field for "flavor Name" | user visits '/flavor/create' | show treat form |
| When user clicks submit on flavor form, add new flavor to List and redirect to '/flavors' | clicks submit | Add new flavor to List, redirect to '/flavors' |


## Setup/Installation Requirements

Clone this repository via Terminal using the following commands:
* ```$ cd desktop```
* ```$ git clone https://github.com/brandanpdx/sweet-treats```
* ```$ cd sweet-treats```

To run the program, first navigate to the SweetTreats production folder by typing the following into the terminal: 

* ```$ cd SweetTreats```

Then restore dependencies by typing:
* ```$ dotnet restore```

Then update your MySQL database by typing: 
* ```$ dotnef ef database update```

You can now run the program by typing:
* ```$ dotnet run```


## Support and Contact

Please email Brandan Sayarath: brandan@brandan.tech for any questions.

## Technologies Used

This program was created with:

* C#
* ASP.NET Core MVC 2.2
* Entity Framework
* Identity 
* MySQL
* MySQL Workbench 
* HTML5

## License

This code is licensed under MIT permissive free software license

Copyright (c) 2020 Brandan Sayarath

