using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortalNunit.Utilities;

namespace TurnupPortalNunit.Pages
{
    public class EmployeePage
    {
        private readonly IWebDriver driver;
        public EmployeePage(IWebDriver driver)
        {
            this.driver = driver;

        }
        IWebElement create => driver.FindElement(By.XPath("//a[normalize-space()='Create']"));

        IWebElement name => driver.FindElement(By.XPath("//input[@id='Name']"));

        IWebElement Username => driver.FindElement(By.Id("Username"));

        IWebElement Id => driver.FindElement(By.Id("ContactDisplay"));

        IWebElement pwd => driver.FindElement(By.Id("Password"));

        IWebElement retypepwd => driver.FindElement(By.Id("RetypePassword"));

        IWebElement checkbox => driver.FindElement(By.XPath("//input[@class=\"check-box\"]"));

        IWebElement vehicle => driver.FindElement(By.Name("VehicleId_input"));
        IWebElement group => driver.FindElement(By.XPath("//div[@class='k-widget k-multiselect k-header']"));
        IWebElement selgroup => driver.FindElement(By.XPath("(//li[text()=\"Aussie group\"])[1]"));
        IWebElement save => driver.FindElement(By.Id("SaveButton"));
        IWebElement backtolist => driver.FindElement(By.LinkText("Back to List"));
        IWebElement gotolastpage => driver.FindElement(By.XPath("//span[text()=\"Go to the last page\"]"));
        IWebElement nam => driver.FindElement(By.XPath("/ html[1] / body[1] / div[4] / div[1] / div[1] / div[3] / table[1] / tbody[1] / tr[last()] / td[1]"));
        IWebElement editbtn => driver.FindElement(By.XPath("//body[1]/div[4]/div[1]/div[1]/div[3]/table[1]/tbody[1]/tr[last()]/td[last()]/a[1]"));
        IWebElement check => driver.FindElement(By.XPath("//input[@class=\"check-box\"]"));
        IWebElement editsave => driver.FindElement(By.Id("SaveButton"));
        IWebElement deleterec => driver.FindElement(By.XPath("//tbody/tr[last()]/td[last()]/a[2]"));
        IAlert Deletealert => driver.SwitchTo().Alert();
        //Function to Create Employee Record
        public void CreateEmployee(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            create.Click();
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//input[@id='Name']", 5);

                name.SendKeys("Saipraneeth");

                Username.SendKeys("sai");

                Id.SendKeys("0469802333");

                pwd.SendKeys("Turnupportal@1");

                retypepwd.SendKeys("Turnupportal@1");

                checkbox.Click();
                vehicle.SendKeys("HRV");
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='k-widget k-multiselect k-header']", 10);
                group.Click();
                Wait.WaitToBeVisible(driver, "XPath", "(//li[text()=\"Aussie group\"])[1]", 10);
                selgroup.Click();
                Thread.Sleep(3000);
                save.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            backtolist.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//span[text()=\"Go to the last page\"]", 10);
            gotolastpage.Click();
            Wait.WaitToBeVisible(driver, "XPath", "(//tbody/tr)[last()]/td[1][text()='Saipraneeth']", 10);

        }
        //Function to Check if Employee Record is created
        public string IsEmployeecreated()
        {
            return nam.Text;
        }
        //Function to Edit Employee Record
        public void Editemployee(IWebDriver driver)
        {
            editbtn.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//input[@class=\"check-box\"]", 10);
            check.Click();
            editsave.Click();
            backtolist.Click();
            Console.WriteLine("Employee edited");
            gotolastpage.Click();

        }
        //Function to Delete Employee Record 
        public void Deleteemployee(IWebDriver driver)
        {
            deleterec.Click();
            Thread.Sleep(2000);
            Deletealert.Accept();
            Console.WriteLine("Employee record deleted");
        }
    }

}


