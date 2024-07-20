using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using TurnupPortalNunit.Utilities;

namespace TurnupPortalNunit.Pages
{
    public class TMPage
    {
        private readonly IWebDriver driver;
        public TMPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        // Bylocators
        IWebElement createnew => driver.FindElement(By.XPath("//a[normalize-space()='Create New']"));
        IWebElement Typecode => driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));

        IWebElement Time => driver.FindElement(By.XPath("/ html[1] / body[1] / div[5] / div[1] / ul[1] / li[2]"));

        IWebElement Code => driver.FindElement(By.Id("Code"));

        IWebElement Description => driver.FindElement(By.Id("Description"));

        IWebElement Pricefield => driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

        IWebElement Pricevalue => driver.FindElement(By.Id("Price"));

        IWebElement Save => driver.FindElement(By.Id("SaveButton"));

        IWebElement Lastbtn => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));


        IWebElement value => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        IWebElement Editbtn => driver.FindElement(By.XPath("//tbody/tr[last()]/td[last()]/a[1]"));
        IWebElement Typebtn => driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));

        IWebElement Material => driver.FindElement(By.XPath("/ html[1] / body[1] / div[5] / div[1] / ul[1] / li[1]"));
        IWebElement pricefield => driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

        IWebElement priceclr => driver.FindElement(By.Id("Price"));
        IWebElement Pfield => driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        IWebElement Priceupdatedvalue => driver.FindElement(By.Id("Price"));
        IWebElement save => driver.FindElement(By.Id("SaveButton"));

        IWebElement lastrec => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

        IWebElement editedvalue => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
        IWebElement delrecord => driver.FindElement(By.XPath("//tbody/tr[last()]/td[last()]/a[2]"));
        IAlert Deletealert => driver.SwitchTo().Alert();

        // Function to Create TM Record
        public void CreateTMRecord()
        {
            createnew.Click();
            Typecode.Click();
            Time.Click();
            Code.SendKeys("TA Prog sai");
            Description.SendKeys("This is a Description");
            Pricefield.Click();
            Pricevalue.SendKeys("22");
            Save.Click();
            Thread.Sleep(2000);
            Lastbtn.Click();
        }
        // Function to check if TM is created
        public string IsTMCreated()
        {
            return value.Text;
        }
        // Function to Edit TM Record
        public void EditTMRecord()
        {
            Editbtn.Click();
            Wait.WaitToBeClickable(driver, "Xpath", "//*[@id=\\\"TimeMaterialEditForm\\\"]/div/div[1]/div/span[1]/span/span[2]/span", 15);
            Typebtn.Click();
            Wait.WaitToBeVisible(driver, "Xpath", "/ html[1] / body[1] / div[5] / div[1] / ul[1] / li[1]", 15);
            Material.Click();
            pricefield.Click();
            priceclr.Clear();
            Pfield.Click();
            Wait.WaitToBeVisible(driver, "Id", "Price", 10);
            Priceupdatedvalue.SendKeys("82");
            Thread.Sleep(2000);
            Save.Click();
            Thread.Sleep(2000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 20);
            lastrec.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]", 10);

        }
        //Function to check if Tm Record is edited
        public string IsTMRecordEdited()
        {
            return editedvalue.Text;
        }
        //Function to Delete TM Record
        public void DeleteTMRecord()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            delrecord.Click();
            Deletealert.Accept();
        }
    }
}