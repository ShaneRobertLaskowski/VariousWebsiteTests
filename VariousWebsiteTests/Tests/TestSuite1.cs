using Allure.Net.Commons;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Allure.Attributes;
using OpenQA.Selenium.DevTools.V120.Target;
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
    public class TestSuite1 : BaseTestClass
    {
        private const string CsvFileName = "";

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
        public TestSuite1() : base()
        {
            //meh
        }

        public TestSuite1(string nameOfDriver) : base(nameOfDriver)
        {
            //stuff
        }


        [TestCaseSource(nameof(getHardCodedData))]
        [Test]
        public void TestNumberOne(string testdataitem)
        {
            List<(string?,object?)> testParams = new List<(string?, object?)>();
            testParams.Add((DriverName, DriverName));
            base.SetAllureDescriptors(testParams, "Test Number 1", "Bob Smith", SeverityLevel.critical);
            //Console.WriteLine(testdataitem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<string> getHardCodedData()
        {
            List<string> inputData = new List<string>();
            inputData.Add("test item 1");
            inputData.Add("test item 2");
            inputData.Add("test item 3");

            return inputData;
        }

        /// <summary>
        /// NEED to not hardcode data in this test method
        /// </summary>
        /// <param name="testData"></param>
        [TestCaseSource(nameof(GetCsvData), new object[] {"sampleCSVtestFile.csv"})]
        [Test]
        public void TestNumberTwo(List<string> testData)
        {
            List<(string?, object?)> testParams = new List<(string?, object?)>();
            testParams.Add((DriverName, DriverName));
            base.SetAllureDescriptors(testParams, "Test Number 2", "Jane Smith", SeverityLevel.normal);
            foreach (string dataPoint in testData)
                Console.WriteLine(dataPoint);
        }

        public static List<List<string>> GetCsvData(string csvFileName)
        {
            List<List<string>> testData = RetrieveCsvData(csvFileName);
            return testData;
        }

    }
}
