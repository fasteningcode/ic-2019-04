using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnup.Helpers;

namespace turnup.Pages
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement username => driver.FindElement(By.Id("UserName"));
        IWebElement password => driver.FindElement(By.Id("Password"));

        public void loginSteps()
        {

            //launch the url
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?");
            driver.Manage().Window.Maximize();

            //Enter valid username
            //IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            //Enter valid password
            //IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            try
            {
                //Click on login button
                IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
                loginButton.Click();

                //Verify if you are on the homescreen

                //identify 'hello hari'
                IWebElement helloHomepage = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

                Assert.That(helloHomepage.Text, Is.EqualTo("Hello hari!"));

            }
            catch (Exception e)
            {
                Console.WriteLine("error occured during the launch of homepage", e.Message);
            }



        }

    }
}
