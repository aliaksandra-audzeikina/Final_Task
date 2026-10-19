using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Final_Task.Core
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                _ => throw new ArgumentException("Browser not supported: " + browser)
            };
        }
    }
}
