using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortalNunit.Utilities;

namespace TurnupPortalNunit.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        // By locators:

        IWebElement Username => driver.FindElement(By.Id("UserName"));
        IWebElement Password => driver.FindElement(By.Id("Password"));
        IWebElement Login => driver.FindElement(By.XPath("//input[@value='Log in']"));

        //Function that allow users to login 
        public void LoginActions()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            Wait.WaitToBeVisible(driver, "Id", "UserName", 5);
            Username.SendKeys("hari");
            Password.SendKeys("123123");
            Login.Click();
        }

    }
}

