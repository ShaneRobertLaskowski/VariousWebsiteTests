using Allure.Net.Commons;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariousWebsiteTests.Pages;

namespace VariousWebsiteTests.Tests
{
    [TestFixture("GeckoDriver")]
    [TestFixture("EdgeDriver")]
    [TestFixture("ChromeDriver")]
    public class Test1 : BaseTestClass
    {
        /// <summary>
        /// this Nunit Setup method should be called after the base class setup is ran as per Nunit Doc.
        /// make sure its not overiding the base class method.
        /// </summary>
        [SetUp]
        protected void SetUp()
        {
            //should go back and change this to the child class of the BaseWebpage class
            BaseWebpage b = new BaseWebpage(base.Driver);
            b.MaximizeBrowserWindow();
        }
        public Test1() : base()
        {
            //meh
        }

        public Test1(string nameOfDriver) : base(nameOfDriver)
        {
            //stuff
        }


        [TestCaseSource(nameof(getCSVData))]
        [Test]
        public void TestNumberOne(string testdataitem)
        {
            List<(string?,object?)> testParams = new List<(string?, object?)>();
            testParams.Add((DriverName, DriverName));
            base.SetAllureDescriptors(testParams, "Test Number 1", "Bob Smith", SeverityLevel.critical);
            //Console.WriteLine(testdataitem);
        }

        public static List<string> getCSVData()
        {
            List<string> inputData = new List<string>();
            inputData.Add("test item 1");
            inputData.Add("test item 2");
            inputData.Add("test item 3");

            return inputData;
        }
    }
}
