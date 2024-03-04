using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace VariousWebsiteTests.Pages
{
    //once child class is made, make the methods protected
    internal class BaseWebpage
    {
        private string? url;
        private IWebDriver? driver;
        
        public BaseWebpage(IWebDriver? driver)
        {
            this.Driver = driver;
            Url = "";
        }
        public BaseWebpage(IWebDriver driver, string webpageURL)
        {
            this.Driver = driver;
            this.Url = webpageURL;
        }

        public IWebDriver? Driver { get => driver; set => driver = value; }
        public string? Url { get => url; set => url = value; }

        public void MaximizeBrowserWindow()
        {
            if(Driver!= null)
                Driver.Manage().Window.Maximize();
        }
    }
}
