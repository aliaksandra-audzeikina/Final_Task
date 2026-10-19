using OpenQA.Selenium;

namespace Final_Task.Pages
{
    public class LoginPage : BasePages
    {
        private readonly By _usernameInput = By.CssSelector("[data-test='username']");
        private readonly By _passwordInput = By.CssSelector("[data-test='password']");
        private readonly By _loginButton = By.CssSelector("[data-test='login-button']");
        private readonly By _errorMessage = By.CssSelector("h3[data-test='error']");
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public void EnterUsername(string username)
        {
            _driver.FindElement(_usernameInput).SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            _driver.FindElement(_passwordInput).SendKeys(password);
        }
        public void ClickLoginButton()
        {
            _driver.FindElement(_loginButton).Click();
        }
        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }
        public void ClearPasswordField()
        {
            var passwordInput = _driver.FindElement(_passwordInput);
            passwordInput.Click();
            passwordInput.SendKeys(Keys.Control + "a");
            passwordInput.SendKeys(Keys.Delete);
        }
        public string GetErrorMessage()
        {
            return _waitHelper.Until(driver =>
            {
                var errorMessage = driver.FindElement(_errorMessage);
                return errorMessage.Displayed ? errorMessage.Text : null;
            }) ?? throw new InvalidOperationException("Error message is not displayed.");
        }

        
    }
}
