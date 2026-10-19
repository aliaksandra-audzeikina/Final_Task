using OpenQA.Selenium;
using NUnit.Framework.Interfaces;

namespace Final_Task.Core
{
    public abstract class BaseTest
    {
        protected IWebDriver _driver;
        protected readonly string _browser;
        protected BaseTest(string browser)
        {
            _browser = browser;
        }
        [SetUp]
        public void Setup()
        {
            _driver = DriverFactory.CreateDriver(_browser);

            _driver.Navigate().GoToUrl(TestSettings.BaseUrl);

            TestContext.Progress.WriteLine($"[SETUP] Navigated to {TestSettings.BaseUrl} on {_browser} browser.");

            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed && _driver is ITakesScreenshot screenshotDriver)
            {
                try
                {
                    var screenshotsDirectory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Screenshots");

                    Directory.CreateDirectory(screenshotsDirectory);

                    var testName = string.Concat(TestContext.CurrentContext.Test.Name.Select(c => Path.GetInvalidFileNameChars().Contains(c) ? '_' : c));

                    var fileName = $"{testName}_{Guid.NewGuid():N}.png";
                    var filePath = Path.Combine(screenshotsDirectory, fileName);

                    screenshotDriver.GetScreenshot().SaveAsFile(filePath);

                    TestContext.AddTestAttachment(filePath, "Screenshot on failure");
                }
                catch (Exception exception)
                {
                    TestContext.Error.WriteLine(
                        $"Failed to save screenshot: {exception.Message}");
                }
            }

            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
