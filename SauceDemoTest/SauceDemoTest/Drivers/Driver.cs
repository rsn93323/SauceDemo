using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SauceDemoTest.Drivers
{
    public class Driver
    {
        //Since using samve object across different classes, static will ensure all methods will be used on only 1 instance when when running tests
        public static IWebDriver _driver; 

        [SetUp]
        public void InitScript()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
