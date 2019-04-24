using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnup.Helpers
{
    public class Wait
    {
        //generic wait method
        public static void waitUntil(IWebDriver driver, int timeSeconds, string locatorValue, string locatorType)
        {
            if (locatorType == "XPath")
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSeconds));
                wait.Until(c => c.FindElement(By.XPath(locatorValue)));
            }
            if (locatorType == "ID")
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSeconds));
                wait.Until(c => c.FindElement(By.Id(locatorValue)));
            }
        }
    }
}
