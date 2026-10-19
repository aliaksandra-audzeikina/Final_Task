using OpenQA.Selenium;

namespace Final_Task.Pages
{
    public class InventoryPage : BasePages
    {
        private readonly By _inventoryContainer = By.CssSelector("[data-test='inventory-container']");
        private readonly By _menuButton = By.CssSelector("[data-test='open-menu']");
        private readonly By _appLogo = By.CssSelector(".app_logo");
        private readonly By _shoppingCartButton = By.CssSelector("[data-test='shopping-cart-link']");
        private readonly By _productSortContainer = By.CssSelector("[data-test='product-sort-container']");
        private readonly By _sauceLabsBackpackLink = By.CssSelector("[data-test='item-4-title-link']");
        private readonly By _shopCartBadge = By.CssSelector("[data-test='shopping-cart-badge']");
        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }
        public bool IsInventoryPageDisplayed()
        {
            return _waitHelper.Until(driver => driver.FindElement(_inventoryContainer).Displayed);
        }
        public bool IsMenuButtonDisplayed()
        {
            return _driver.FindElement(_menuButton).Displayed;
        }
        public string GetAppLogoText()
        {
            return _driver.FindElement(_appLogo).Text;
        }
        public bool IsShoppingCartButtonDisplayed()
        {
            return _driver.FindElement(_shoppingCartButton).Displayed;
        }
        public bool IsProductSortContainerDisplayed()
        {
            return _driver.FindElement(_productSortContainer).Displayed;
        }
        public void OpenSauceLabsBackpackLink()
        {
            // Firefox cannot scroll item link into view,
            // JavaScript click provides cross-browser stability
            var product = _driver.FindElement(_sauceLabsBackpackLink);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", product);
        }

        public string GetShoppingCartBadgeText()
        {
            return _waitHelper.Until(driver =>
            {
                var badge = driver.FindElement(_shopCartBadge);
                return badge.Displayed ? badge.Text : null;
            }
            ) ?? throw new InvalidOperationException("Shopping cart badge is not displayed.");
        }
    }
}
