using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Final_Task
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class Tests
    {
        private IWebDriver _driver;
        private readonly string _browser;

        public Tests(string browser)
        {
            _browser = browser;
        }

        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine($"[SETUP] Running test on {_browser} browser.");

            _driver = DriverFactory.CreateDriver(_browser);

            TestContext.Progress.WriteLine($"[SETUP] {_browser} browser initialized successfully.");

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            TestContext.Progress.WriteLine($"[SETUP] Navigated to https://www.saucedemo.com/ on {_browser} browser.");

            _driver.Manage().Window.Maximize();
        }

        [TestCase("standard_user", "secret_sauce")]
        [TestCase("locked_out_user", "secret_sauce")]
        [TestCase("problem_user", "secret_sauce")]
        [TestCase("performance_glitch_user", "secret_sauce")]
        [TestCase("error_user", "secret_sauce")]
        [TestCase("visual_user", "secret_sauce")]
        [Test]
        public void LoginWithOnlyUsernameExpectedErrorMessage(string username, string password)
        {
            TestContext.Progress.WriteLine($"[TEST] Running test with username and cleared password");

            _driver.FindElement(By.CssSelector("[data-test='username']")).SendKeys(username);

            var passwordInput = _driver.FindElement(By.CssSelector("[data-test='password']"));
            passwordInput.SendKeys(password);

            TestContext.Progress.WriteLine($"[ACTION] Entered username: {username} and password");

            passwordInput.Click();
            passwordInput.SendKeys(Keys.Control + "a");
            passwordInput.SendKeys(Keys.Delete);

            TestContext.Progress.WriteLine($"[CHECK] Password field after clearing: {passwordInput.GetAttribute("value")}");

            _driver.FindElement(By.CssSelector("[data-test='login-button']")).Click();

            TestContext.Progress.WriteLine($"[ACTION] Clicked login button with username: {username} and empty password field.");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            TestContext.Progress.WriteLine($"[WAIT] Waiting for error message to be displayed.");

            wait.Until(_driver => _driver.FindElement(By.CssSelector("h3[data-test='error']")).Displayed);

            TestContext.Progress.WriteLine($"[ASSERT] Error message displayed: {_driver.FindElement(By.CssSelector("h3[data-test='error']")).Text}");

            _driver.FindElement(By.CssSelector("h3[data-test='error']")).Text.Should().Contain("Password is required");

            TestContext.Progress.WriteLine($"[TEST PASSED] Error message displayed correctly.");
        }

        [Test]
        public void LoginWithValidCredentialsExpectedOpen()
        {

            TestContext.Progress.WriteLine($"[TEST] Running test with valid credentials.");

            Login("standard_user", "secret_sauce");

            TestContext.Progress.WriteLine($"[ACTION] Entered valid credentials and clicked login button.");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector("[data-test='inventory-list']")).Displayed);

            TestContext.Progress.WriteLine($"[ASSERT] Checking if the main page elements are displayed correctly.");

            _driver.FindElement(By.CssSelector("[data-test='open-menu']")).Displayed.Should().BeTrue();
            _driver.FindElement(By.CssSelector(".app_logo")).Text.Should().Be("Swag Labs");
            _driver.FindElement(By.CssSelector("[data-test='shopping-cart-link']")).Displayed.Should().BeTrue();
            _driver.FindElement(By.CssSelector("[data-test='product-sort-container']")).Displayed.Should().BeTrue();
            _driver.FindElement(By.CssSelector("[data-test='inventory-container']")).Displayed.Should().BeTrue();

            TestContext.Progress.WriteLine($"[TEST PASSED] Main page elements are displayed correctly after login.");
        }

        [Test]
        public void AddingProductsToShoppingCartExpectedDisplaysNumberOfAddedProducts()
        {
            TestContext.Progress.WriteLine($"[TEST] Running test for adding products to shopping cart.");

            Login("standard_user", "secret_sauce");

            TestContext.Progress.WriteLine($"[ACTION] Entered valid credentials and clicked login button.");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector("[data-test='inventory-list']")).Displayed);

            // Firefox cannot scroll item link into view,
            // JavaScript click provides cross-browser stability
            var product = _driver.FindElement(By.CssSelector("[data-test='item-4-title-link']"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", product);

            TestContext.Progress.WriteLine($"[ACTION] Clicked on Sauce Labs Backpack product to view its details.");

            wait.Until(driver => driver.FindElement(By.CssSelector("[data-test='back-to-products']")).Displayed);

            TestContext.Progress.WriteLine($"[ACTION] Product page displayed.");

            _driver.FindElement(By.CssSelector("[data-test='add-to-cart']")).Click();

            TestContext.Progress.WriteLine($"[ACTION] Clicked 'Add to cart' button for the product.");

            wait.Until(driver => driver.FindElement(By.CssSelector("span[data-test='shopping-cart-badge']")).Displayed);
            _driver.FindElement(By.CssSelector("span[data-test='shopping-cart-badge']")).Text.Should().Be("1");

            TestContext.Progress.WriteLine($"[TEST PASSED] Number of added products displayed correctly.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }

        private void Login(string username, string password)
        {
            _driver.FindElement(By.CssSelector("[data-test='username']")).SendKeys(username);
            _driver.FindElement(By.CssSelector("[data-test='password']")).SendKeys(password);
            _driver.FindElement(By.CssSelector("[data-test='login-button']")).Click();
        }
    }
}
