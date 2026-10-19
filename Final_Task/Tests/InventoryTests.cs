using Final_Task.Core;
using Final_Task.Pages;
using Final_Task.TestData;
using FluentAssertions;

namespace Final_Task.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(BrowserNames.Chrome)]
    [TestFixture(BrowserNames.Firefox)]
    public class InventoryTests : BaseTest
    {
        public InventoryTests(string browser) : base(browser)
        {
        }
   
        [Test]
        public void AddingProductsToShoppingCartExpectedDisplaysNumberOfAddedProducts()
        {
            TestContext.Progress.WriteLine($"[TEST] Running test for adding products to shopping cart.");

            var loginPage = new LoginPage(_driver);
            loginPage.Login(TestUsers.StandardUser, TestUsers.Password);

            var inventoryPage = new InventoryPage(_driver);
            inventoryPage.IsInventoryPageDisplayed().Should().BeTrue();

            inventoryPage.OpenSauceLabsBackpackLink();

            var productPage = new ProductPage(_driver);

            productPage.IsBackToProductsButtonDisplayed().Should().BeTrue();
            productPage.ClickAddToCartButton();

            TestContext.Progress.WriteLine($"[ASSERT] Checking the text of the shopping cart badge.");

            inventoryPage.GetShoppingCartBadgeText().Should().Be("1");

            TestContext.Progress.WriteLine($"[TEST PASSED] Number of added products displayed correctly.");
        }
    }
}
