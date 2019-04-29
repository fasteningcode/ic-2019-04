using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

            ExcelHelpers.PopulateInCollection(@"C:\Users\aadhith.bose\OneDrive\dropbox\Industry Connect\10 AutomationTesting\2019 April\Github\ic-2019-04\turnup\Data\testdata1.xlsx", "Sheet1");

           
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
