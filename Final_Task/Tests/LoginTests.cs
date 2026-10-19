using Final_Task.Core;
using Final_Task.Pages;
using Final_Task.TestData;
using FluentAssertions;

namespace Final_Task.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(BrowserNames.Chrome)]
    [TestFixture(BrowserNames.Firefox)]
    public class LoginTests : BaseTest
    {
        public LoginTests(string browser) : base(browser)
        {
        }

        [TestCase(TestUsers.StandardUser, TestUsers.Password)]
        [TestCase(TestUsers.ErrorUser, TestUsers.Password)]
        public void LoginWithOnlyUsernameExpectedErrorMessage(string username, string password)
        {
            TestContext.Progress.WriteLine($"[TEST] Running test with username and cleared password");

            var loginPage = new LoginPage(_driver);
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            loginPage.ClearPasswordField();
            loginPage.ClickLoginButton();

            loginPage.GetErrorMessage().Should().Contain("Password is required");

            TestContext.Progress.WriteLine($"[TEST PASSED] Error message displayed correctly.");
        }

        [Test]
        public void LoginWithValidCredentialsExpectedOpen()
        {

            TestContext.Progress.WriteLine($"[TEST] Running test with valid credentials.");

            var loginPage = new LoginPage(_driver);
            loginPage.Login(TestUsers.StandardUser, TestUsers.Password);

            var inventoryPage = new InventoryPage(_driver);

            TestContext.Progress.WriteLine($"[ASSERT] Checking if the main page elements are displayed correctly.");

            inventoryPage.IsInventoryPageDisplayed().Should().BeTrue();
            inventoryPage.IsMenuButtonDisplayed().Should().BeTrue();
            inventoryPage.GetAppLogoText().Should().Be("Swag Labs");
            inventoryPage.IsShoppingCartButtonDisplayed().Should().BeTrue();
            inventoryPage.IsProductSortContainerDisplayed().Should().BeTrue();

            TestContext.Progress.WriteLine($"[TEST PASSED] Main page elements are displayed correctly after login.");
        }
    }
}
