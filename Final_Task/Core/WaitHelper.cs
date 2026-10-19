using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Final_Task.Core
{
    public class WaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestSettings.DefaultTimeoutInSeconds));
        }
        public T? Until<T>(Func<IWebDriver, T?> condition)
        {
            return _wait.Until(condition);
        }
    }
}
