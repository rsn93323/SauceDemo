using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoTest.Source.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SauceDemoTest.Drivers;

namespace SauceDemoTest.Tests
{
    public class LoginTest : Driver
    {
        

        //Verify if user can login with valid credentials
        [Test]
        public void UserLogin_ValidCredential()
        {
            LoginPage homepageobj = new LoginPage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homepageobj.Login("standard_user", "secret_sauce");
            Assert.True(_driver.FindElements(By.ClassName("shopping_cart_link")).Count > 0, 
                "Shopping cart link not found on the page, Therefore unsucessful user login");//Shopping cart link class is accessible only for the sucessfully logged in users
        }

        //Verify if user can't login with an invalid username
        [Test]
        public void UserLogin_InvalidUser()
        {
            LoginPage homepageobj = new LoginPage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homepageobj.Login("InvalidUser", "secret_sauce");
            Assert.IsFalse(_driver.FindElements(By.ClassName("shopping_cart_link")).Count > 0, 
                "Shopping cart link is found on the page. Therefore sucessful user login with invalid userame");
        }

        //Verify is user can't login with a valid username with invalid password
        [Test]
        public void UserLogin_ValidUser_InvalidPassword()
        {
            LoginPage homepageobj = new LoginPage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homepageobj.Login("standard_user", "InvalidPassword");
            Assert.IsFalse(_driver.FindElements(By.ClassName("shopping_cart_link")).Count > 0, 
                "Shopping cart link is found on the page. Therefore sucessful user login with invalid password");
        }

        //Verify that user can't login with a blank username
        [Test]
        public void UserLogin_BlankUser()
        {
            LoginPage homepageobj = new LoginPage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homepageobj.Login("", "secret_sauce");
            Assert.IsFalse(_driver.FindElements(By.ClassName("shopping_cart_link")).Count > 0, 
                "Shopping cart link is found on the page. Therefore sucessful user login with blank username and valid password");
        }

        //Verify that user can't login with a blank password
        [Test]
        public void UserLogin_ValidUser_BlankPassword()
        {
            LoginPage homepageobj = new LoginPage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homepageobj.Login("standard_user", "");
            Assert.IsFalse(_driver.FindElements(By.ClassName("shopping_cart_link")).Count > 0, 
                "Shopping cart link is found on the page. Therefore sucessful user login with valid username and invalid password");
        }

        //Verify that user can't login with a blank username and blank password
        [Test]
        public void UserLogin_BlankCredentials()
        {
            LoginPage homepageobj = new LoginPage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homepageobj.Login("", "");
            Assert.IsFalse(_driver.FindElements(By.ClassName("shopping_cart_link")).Count > 0,
                "Shopping cart link is found on the page. Therefore sucessful user login with blank username and blank password");
        }

        //Verify that an error message is present when a blank username is entered
        [Test]
        public void UserLogin_BlankUser_DisplayErrorButton()
        {
            LoginPage homepageobj = new LoginPage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homepageobj.Login("", "secret_sauce");

            Assert.IsTrue(_driver.FindElements(By.ClassName("error-button")).Count > 0, 
                "error-button is not present");
        }

        //Verify that an error message block is present when a invalid username is entered 
        [Test]
        public void UserLogin_Invalid_DisplayErrorButton()
        {
            LoginPage homepageobj = new LoginPage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homepageobj.Login("InvalidUser", "secret_sauce");

            Assert.IsTrue(_driver.FindElements(By.ClassName("error-button")).Count > 0,
                "error-button is not present");
        }

        //Verify that error message: "Epic sadface: Username is required" is present when entering a blank username
        [Test]
        public void UserLogin_PresentErrorMessage_BlankUser()
        {
            LoginPage homepageobj = new LoginPage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homepageobj.Login("", "secret_sauce");

            var errorElement = _driver.FindElement(By.TagName("h3"));
            string errorMessage = errorElement.Text;

            string expectedErrorMessage = "Epic sadface: Username is required";

            Assert.IsTrue(errorMessage.Contains(expectedErrorMessage), 
                "Error message mismatch.");
        }

        //Verify that error message: "Epic sadface: Password is required" is present when entering a blank password
        [Test]
        public void UserLogin_PresentErrorMessage_BlankPassword()
        {
            LoginPage homepageobj = new LoginPage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homepageobj.Login("standard_user", "");

            var errorElement = _driver.FindElement(By.TagName("h3"));
            string errorMessage = errorElement.Text;

            string expectedErrorMessage = "Epic sadface: Password is required";

            Assert.IsTrue(errorMessage.Contains(expectedErrorMessage),
                "Error message mismatch.");
        }

        //Verify that error message: "Epic sadface: Username is required" is present when entering a blank credentials
        [Test]
        public void UserLogin_PresentErrorMessage_BlankCredential()
        {
            LoginPage homepageobj = new LoginPage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homepageobj.Login("", "");

            var errorElement = _driver.FindElement(By.TagName("h3"));
            string errorMessage = errorElement.Text;

            string expectedErrorMessage = "Epic sadface: Username is required";

            Assert.IsTrue(errorMessage.Contains(expectedErrorMessage),
                "Error message mismatch.");
        }
    }
}
