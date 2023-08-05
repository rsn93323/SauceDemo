using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SauceDemoTest.Drivers;

namespace SauceDemoTest.Source.Pages
{
    public class LoginPage : Driver
    {

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement _username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _password;

        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement _loginButton;

        [FindsBy(How = How.Id, Using = "error-button")]
        private IWebElement _errorButton;


        public LoginPage()
        {
            PageFactory.InitElements(_driver, this);
        }

        public void Login(string username, string password)
        {
            _username.SendKeys(username);
            _password.SendKeys(password);
            _loginButton.Click();
        }
    }
}
