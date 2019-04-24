using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnup.Helpers
{
    class TMHelpers
    {
        public static void addTM(IWebDriver driver, string code, string description, string price)
        {
            //Click "Create New" button 
            IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createnewButton.Click();

            //Click dropdown box from "TypeCode"
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeCodeDropdown.Click();
            System.Threading.Thread.Sleep(1000);

            //Click "Material" option from "Time" in "TypeCode" dropdown
            IWebElement timeCodeLink = driver.FindElement(By.XPath("/html[1]/body[1]/div[5]/div[1]/ul[1]/li[2]"));
            timeCodeLink.Click();

            //Enter valid data in "Code" text field 
            IWebElement codeField = driver.FindElement(By.XPath("//*[@id='Code']"));
            codeField.SendKeys(code);

            //Enter valid data in "Description" text field 
            IWebElement descriptionField = driver.FindElement(By.XPath("//*[@id='Description']"));
            descriptionField.SendKeys(description);

            //Enter valid data in "Price per unit" text field 
            IWebElement priceField = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceField.SendKeys(price);

            //"Select files" and upload any files from the desktop
            //IWebElement selectFilesButton = driver.FindElement(By.XPath("//div[@class='k-button k-upload-button']"));
            //System.Threading.Thread.Sleep(1000);
            //selectFilesButton.Click();
            //System.Windows.Forms.SendKeys.SendWait(@"D:\test.txt");
            //System.Windows.Forms.SendKeys.SendWait(@"{Enter}");

            //System.Threading.Thread.Sleep(2000);

            //Click "Save" button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
        }

        //generic method to see if we have a TM record
        public static bool isExistsTM(IWebDriver driver)
        {
            IWebElement firstRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
            if (firstRecord.Displayed)
            {
                return true;
            }
            return false;

        }

    }
}
