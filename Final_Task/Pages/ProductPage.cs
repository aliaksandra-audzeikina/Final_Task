using OpenQA.Selenium;

namespace Final_Task.Pages
{
    public class ProductPage : BasePages
    {
        private readonly By _backToProductsButton = By.CssSelector("[data-test='back-to-products']");
        private readonly By _addToCartButton = By.CssSelector("[data-test='add-to-cart']");
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }
        public bool IsBackToProductsButtonDisplayed()
        {
            return _waitHelper.Until(driver => driver.FindElement(_backToProductsButton).Displayed);
        }
        public void ClickAddToCartButton()
        {
            _driver.FindElement(_addToCartButton).Click();
        }
    }
}
