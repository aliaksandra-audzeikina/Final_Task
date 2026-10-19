using Final_Task.Core;
using OpenQA.Selenium;

namespace Final_Task.Pages
{
    public abstract class BasePages
    {
        protected readonly IWebDriver _driver;
        protected readonly WaitHelper _waitHelper;
        protected BasePages(IWebDriver driver)
        {
            _driver = driver;
            _waitHelper = new WaitHelper(_driver);
        }
    }
}
