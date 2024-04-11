using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace VariousWebsiteTests.Pages.SanDiegoZoo
{
    class homepage
    {
        public const string URL= "https://sandiegozoowildlifealliance.org/";
        public const string GIVE_ONCE_BTN_XPATH =
            "//*[@id=\"header-buttons-menu-link-contentcd006680-7a4f-4dd4-97a6-bc24b87e5680\"]/a";

        private IWebDriver browserDriver;

        homepage(IWebDriver driver)
        {
            this.browserDriver = driver;
        }

        public void clickDonateNowButton()
        { 
            browserDriver.FindElement(By.XPath(GIVE_ONCE_BTN_XPATH)).Click();
        }

    }
}
