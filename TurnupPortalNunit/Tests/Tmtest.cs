using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Diagnostics;
using TurnupPortalNunit.Pages;
using TurnupPortalNunit.Utilities;
using static TurnupPortalNunit.Pages.TMPage;


namespace TurnupPortalNunit.Tests
{
    [TestFixture]
    public class Tmtest : DriverFactory
    {

        [Test, Order(1)]
        public void CreateTime_Test()
        {
            //LoginPageobject Initialization and Definition
            LoginPage loginpageobj = new LoginPage(driver);
            loginpageobj.LoginActions();
            //HomePageobject Initialization and Definition
            HomePage homepageobj = new HomePage(driver);
            homepageobj.NavigateToTMPage();
            TMPage tmpageobj = new TMPage(driver);
            tmpageobj.CreateTMRecord();
            string iscreated = tmpageobj.IsTMCreated();
            if (iscreated == "TA Prog sai")
            {
                Assert.Pass("Success");
            }
            else
            {
                Assert.Fail("Fail");
            }


        }
        [Test, Order(2)]
        public void EditTime_Test()
        {
            TMPage tmpageobj = new TMPage(driver);
            tmpageobj.EditTMRecord();
            string iscreated = tmpageobj.IsTMRecordEdited();
            if (iscreated == "M")
            {
                Assert.Pass("Success");
            }
            else
            {
                Assert.Fail("Fail");
            }
        }
        [Test, Order(3)]
        public void DeleteTime_Test()
        {
            TMPage tmpageobj = new TMPage(driver);
            tmpageobj.DeleteTMRecord();
        }

    }



}
