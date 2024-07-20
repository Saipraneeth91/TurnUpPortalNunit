using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortalNunit.Pages;
using TurnupPortalNunit.Utilities;

namespace TurnupPortalNunit.Tests
{
    [TestFixture]
    public class EmployeeTest : DriverFactory
    {
        [Test, Order(1)]
        public void CreateEmployee_Test()
        {
            //LoginPageobject Initialization and Definition
            LoginPage loginpageobj = new LoginPage(driver);
            loginpageobj.LoginActions();
            //HomePageobject Initialization and Definition
            HomePage homepageobj = new HomePage(driver);
            homepageobj.NavigateToEmpPage();
            EmployeePage employeepageobj = new EmployeePage(driver);
            employeepageobj.CreateEmployee(driver);
            string name = employeepageobj.IsEmployeecreated();
            if (name == "Saipraneeth")
            {
                Assert.Pass("Employee created");

            }
            else
            {
                Assert.Fail("Employee not created");
            }

        }
        [Test, Order(2)]
        public void EditEmployee_Test()
        {
            EmployeePage employeepageobj = new EmployeePage(driver);
            employeepageobj.Editemployee(driver);
        }
        [Test, Order(3)]
        public void DeleteEmployee_Test()
        {
            EmployeePage employeepageobj = new EmployeePage(driver);
            employeepageobj.Deleteemployee(driver);
        }

    }
}
