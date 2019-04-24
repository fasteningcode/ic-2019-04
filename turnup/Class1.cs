using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnup.Helpers;
using turnup.Pages;

namespace turnup
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Class1
    {

        static void Main(string[] args)
        {

        }
        IWebDriver driver;
        [SetUp]
        public void setup()
        {
            //defining driver
            driver = new ChromeDriver();

            //login object and logging in to TurnUp
            LoginPage loginPage = new LoginPage(driver);
            loginPage.loginSteps();

            //homePage object and navigating to TM page
            HomePage homePage = new HomePage(driver);
            homePage.navigateTM();
        }

        [Test]
        public void CreateTMnValidate()
        {
            var tmPage = new TMPage(driver);
            tmPage.createTM();
            tmPage.ValidateTM();
        }

        [Test]
        public void testEditTM()
        {
            //TMpage object and editing an existing record
            TMPage tmPage = new TMPage(driver);
            tmPage.editTM();
        }

        [Test]
        public void testDeleteTM()
        {
            var tmPage = new TMPage(driver);
            tmPage.createTM();
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }

    }
}
