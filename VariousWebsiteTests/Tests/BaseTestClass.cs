using VariousWebsiteTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using NUnit.Framework.Interfaces;
using Allure.Net.Commons;
using NUnit.Allure.Core;

namespace VariousWebsiteTests.Tests
{
    /// <summary>
    ///     include code that will take screenshot if an Nunit Test fails
    ///     add other test base class stuff too.
    /// </summary>

    //should probably remove these and put in child class?
    //[TestFixture("GeckoDriver")]
    //[TestFixture("EdgeDriver")]
    //[TestFixture("ChromeDriver")]
    [AllureNUnit]
    public class BaseTestClass
    {
        private IWebDriver? driver;
        private string? driverName;

        public IWebDriver? Driver { get => driver; set => driver = value; }
        public string? DriverName { get => driverName; set => driverName = value; }

        public BaseTestClass()
        {
            this.DriverName = "";
        }
        public BaseTestClass(string driverName)
        {
            this.DriverName = driverName;
        }

        [SetUp]
        protected void Setup()
        {
            if (DriverName == "")
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                Driver = new ChromeDriver();
            }
            else if (DriverName == "ChromeDriver")
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                Driver = new ChromeDriver();
            }
            else if (DriverName == "EdgeDriver")
            {
                new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                Driver = new EdgeDriver();
            }
            else if (DriverName == "GeckoDriver")
            {
                Driver = new FirefoxDriver(); //why do they name it FirefoxDriver if its GeckoDriver???
            }
            else throw new ArgumentException("driver name is not valid.");

            Driver.Manage().Cookies.DeleteAllCookies();
            //HomePage hp = new HomePage(driver); //the child test class will create an instance of a POM webpage using this classes driver
        }

        [TearDown]
        protected void TearDown()
        {
            if (Driver != null)
            {
                TakeScreenshotDefaultImageFormat(Driver);
                Driver.Close();
            }
        }

        /// <summary>
        /// takes a single screenshot of the webpage iff the ResultState of the Nunit test is a 
        /// Failure.  This helps the bug/defect review.
        /// </summary>
        /// <param name="driver">the webdriver of the currently opened web browser</param>
        protected void TakeScreenshotDefaultImageFormat(IWebDriver driver)
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                DateTime currentDate = DateTime.Now;
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string? screenshotDirectoryPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Screenshots\\");
                //screenshotDirectoryPath = Path.Combine(screenshotDirectoryPath, currentDate.ToString("yyyy.MM.dd-HH"));
                if (!Directory.Exists(screenshotDirectoryPath))
                    Directory.CreateDirectory(screenshotDirectoryPath);

                string? filePath = $"{screenshotDirectoryPath}{TestContext.CurrentContext.Test.Name}_{currentDate.ToString("yyyy.MM.dd-HH.mm.ss")}.png";
                screenshot.SaveAsFile(filePath);
                TestContext.AddTestAttachment(filePath); //this displays a link to show up in test result VS viewer
            }
        }
        
        /// <summary>
        /// sets up Allure Annotations via the Allure API rather than directly writing in the
        /// Annotations above each Nunit Test method.
        /// </summary>
        /// <param name="testParam">A list of test parameters, usually includes specific webdriver name</param>
        /// <param name="testName">A descriptor for the test name</param>
        /// <param name="owner">The name of the author of the test</param>
        public void SetAllureDescriptors(List<(string?, object?)> testParam, string testName, string owner)
        {
            foreach ((string?, object?) p in testParam)
                if(p.Item1 != null)
                    AllureApi.AddTestParameter(p.Item1, p.Item2); //***when this is line runs: error: No test context is active

            AllureApi.SetTestName(DriverName + " => " + testName);
            AllureApi.SetOwner(owner);
        }

        /// <summary>
        /// sets up Allure Annotations via the Allure API rather than directly writing in the
        /// Annotations above each Nunit Test method.
        /// </summary>
        /// <param name="testParam">A list of test parameters, usually includes specific webdriver name</param>
        /// <param name="testName">A descriptor for the test name</param>
        /// <param name="owner">The name of the author of the test</param>
        /// <param name="severityLevel">Defiens the severity/priority of the test</param>
        public void SetAllureDescriptors(List<(string?, object?)> testParam, string testName,
            string owner, SeverityLevel severityLevel)
        {
            SetAllureDescriptors(testParam, testName, owner);
            AllureApi.SetSeverity(severityLevel);
        }
    }
}