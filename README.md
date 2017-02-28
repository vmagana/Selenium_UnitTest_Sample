# Selenium Sample in C#

C# Selenium program using WebDriver to fill out a user registration form, login to user account and fill out a questions form
These are the Selenium test ran:
UserRegistration
StoreLogin
SelectElem
FillForm

## Getting Started

These test were verified on a Windows 7 system running Visual Studio 2015.

### Prerequisites

The target system(s) need to have rpmbuild binary, ssh and scp programs to work

## Running the tests

Open the project with Visual Studio 2015 IDE
Test->Run->All Tests

### Break down into the tests

UserRegistration test will fill out a form that has input boxes, radio button, check box, drop down options and a submit button.
This test will fail if there is an existing user with same username or email address, that would be expected

StoreLogin enters a username and password into the corresponding fields and reports is login failed or passed

SelectElem is a page with selectable fields and walks thru by highlighting each selectable field, also prints out the field name to the standard output to show it can read the text off the selectable field

FillForm is a general questions form with input box, radio options, check boxes and multiple select options

## Built With

Visual Studio 2015

## Contributing


## Authors


## License


## Acknowledgments

Many thanks and help from tutorials and online practice web pages from http://toolsqa.com/