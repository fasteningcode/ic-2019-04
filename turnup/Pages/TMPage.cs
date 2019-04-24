using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using turnup.Helpers;

namespace turnup.Pages
{
    class TMPage
    {
        private IWebDriver driver;

        public TMPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void createTM()
        {
            TMHelpers.addTM(driver, "testCode", "testDescription", "123");

        }

        public void editTM()
        {

            if (TMHelpers.isExistsTM(driver) == false)
            {
                TMHelpers.addTM(driver, "testCode", "testDescription", "123");
            }

            //Edit an existing Time and Material record

            //Click on Edit for any one record
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]")).Click();

            //Edit/ update a value for the selected record
            driver.FindElement(By.XPath("//*[@id='Code']")).Clear();
            driver.FindElement(By.XPath("//*[@id='Code']")).SendKeys("updatedCode");

            //save the updated record
            driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

            Wait.waitUntil(driver, 3, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", "XPath");

            Thread.Sleep(1000);

            //verify if the record is updated
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));

            if (actualCode.Text == "updatedCode")
            {
                Console.WriteLine("TM record edited successfully, test passed");
            }
            else
            {
                Console.WriteLine("TM record NOT edited, test failed");
            }

        }

        internal void ValidateTM()
        {
            Thread.Sleep(3000);
            while (true)
            {
                for (var i = 1; i <= 10; i++)
                {
                    var elementText = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]")).Text;
                    if (elementText == "Hey123")
                    {
                        Console.WriteLine("Test Passed");
                        return;
                    }
                }
                driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[3]/span")).Click();
            }

        }

        public void deleteTM()
        {
        }
    }
}
