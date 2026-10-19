SauceDemo UI Test Automation

Project Overview

This project was developed as part of the EPAM Fundamentals Automated Testing in .NET learning assignment.
It focuses on automating key UI workflows of the SauceDemo web application using C#, Selenium WebDriver, and NUnit.

The project applies the Page Object Model (POM), reusable test infrastructure, explicit waits, cross-browser testing, parallel execution, and automated failure screenshots.

Original Task Requirements

Site for testing: https://www.saucedemo.com

UC-1 Test Login form with only Username provided:

1. Enter any username.

2. Enter password.

3. Clear the "Password" field.

4. Click the "Login" button.

5. Verify that an error message "Password is required" appears.

UC-2 Test Login form with valid credentials:

1. Enter username for a standard user.

2. Enter a password from the section “Password for all users”.

3. Click “Login” button and verify that main page contains the following elements: burger menu button; label “Swag Labs”; shopping cart icon; dropdown with sorting filters; list of inventory items

UC-3 Test adding products to shopping cart:

1. Login with standard user.

2. Open details of any product by clicking on it.

3. Add product to cart.

4. Verify that the shopping cart icon displays the number of added products.

Technology Stack

Language: C#

Platform: .NET

UI Automation: Selenium WebDriver

Test Runner: NUnit

Assertions: FluentAssertions

Locators: CSS selectors

Browsers: Chrome and Firefox

Project Structure

Core/ — WebDriver factory, base test class, browser names, test settings, and wait helper.

Pages/ — Page Object classes for login, inventory, and product details.

TestData/ — Test users and credentials.

Tests/ — NUnit test scenarios.

How to Run

1. Clone the repository.

2. Open the solution in Visual Studio.

3. Restore NuGet packages.

4. Build the solution.

5. Run the tests using Test Explorer.

Ensure that the required browser and WebDriver setup is available in your environment.

Learning Outcomes

Practiced UI test automation, Page Object Model design, explicit waits, data-driven testing, cross-browser execution, parallel testing, reusable test infrastructure, and failure diagnostics.