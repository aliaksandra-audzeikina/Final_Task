Task description
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

Provide possibility to execute tests in parallel, add logging to track execution flow and use data-driven testing approach.

Make sure that all tasks are supported by these 3 conditions: UC-1; UC-2; UC-3.

Please, add task description as README.md into your solution!

To perform the task use the various of additional options:

Test Automation tool: Selenium WebDriver;

Browsers: 1) Firefox; 2) Chrome;

Locators: CSS;

Test Runner: NUnit;

Assertions: Fluent Assertion;

[Optional] Patterns: Singleton; 2) Factory method; 3) Abstract Factory;

[Optional] Test automation approach: BDD;

[Optional] Loggers: NUnit.