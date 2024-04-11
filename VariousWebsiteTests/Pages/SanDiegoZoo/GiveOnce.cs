using AngleSharp.Dom;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousWebsiteTests.Pages.SanDiegoZoo
{
    internal class GiveOnce
    {
        //this will be stale data (just rely on previous page's <a> clickable action to lead to this page.
        private const string URL =
            "https://secure3.convio.net/sdzoo/site/Donation2;jsessionid=00000000.app30132a?idb=" +
            "1809613969&df_id=15651&mfc_pref=T&15651.donation=form1&NONCE_TOKEN=FAB63E35779570A" +
            "FC18375B701F4074A&15651_donation=form1";
        private IWebDriver browserDriver;
        public GiveOnce(IWebDriver driver)
        {
            this.browserDriver = driver;
        }

        private int[] fixedDonationAmts = {25, 50, 100, 250, 500, 1000 };

        private int variableDonationAmt = 0;
        private const string VAR_DONATION_AMT_FIELD_XPATH = "";

        private const string FIRST_NAME_FIELD_XPATH = "//*[@id=\"billing_first_namename\"]";

        public void ClickDonationLevel(int donationAMTButtonNum)
        {
            browserDriver.FindElement(By.XPath($"//*[@id=\"level_standard_row\"]/div/div[2]/div" +
                $"[{donationAMTButtonNum}]/div/div/label")).Click();       
        }
        public void EnterCustomDonationAMT(decimal moneyAmount, int customDonationButtonNum)
        {
            ClickDonationLevel(customDonationButtonNum);
            browserDriver.FindElement(By.XPath("//*[@id=\"level_standardexpanded54221amount\"]"))
                .SendKeys(moneyAmount.ToString());
        }

        // need to create a struct (note that struct is value type) for all of this form data
        // perhaps add Xpath to the form fields in this struct as well.
        //structs should be immuntable, so make it so.
        public void FillOutForm()
        {
            //do the donation amount (2 methods above)
            //probably need to add exceptions throwing if donationBtnNum = 3 but custonDonationAmt is non-zero.

            //use parameters to fill out rest of form.
        }
        public void ClickDonateButton()
        {
            //clikc that donate button... [in the test (client), expect the browser to fail because i aint using a valid Credit card or real credentials]
            //if their site uses protection against bots, consider simply downloading the website.
        }
    }
}
