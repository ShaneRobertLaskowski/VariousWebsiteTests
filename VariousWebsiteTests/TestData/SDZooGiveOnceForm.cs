using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousWebsiteTests.TestData
{
    internal class SDZooGiveOnceForm
    {
        private static int donationBtnNum;
        private static decimal customDonationAmt;
        private static string? firstName;
        private static string? lastName;
        private static string? email;
        private static string? streetOne;
        private static string? streetTwo;
        private static string? city;
        private static string? state;
        private static string? country;
        private static int ccNum;
        private static int ccExpDateMonthNum;
        private static int ccExpDateYearNum;
        private static int ccCCVNum;

        public int DonationBtnNum { get => donationBtnNum; set => donationBtnNum = value; }
        public decimal CustomDonationAmt { get => customDonationAmt; set => customDonationAmt = value; }
        public string? FirstName { get => firstName; set => firstName = value; }
        public string? LastName1 { get => lastName; set => lastName = value; }
        public string? Email { get => email; set => email = value; }
        public string? StreetOne { get => streetOne; set => streetOne = value; }
        public string? StreetTwo { get => streetTwo; set => streetTwo = value; }
        public string? City { get => city; set => city = value; }
        public string? State { get => state; set => state = value; }
        public string? Country { get => country; set => country = value; }
        public int CcNum { get => ccNum; set => ccNum = value; }
        public int CcExpDateMonthNum { get => ccExpDateMonthNum; set => ccExpDateMonthNum = value; }
        public int CcExpDateYearNum { get => ccExpDateYearNum; set => ccExpDateYearNum = value; }
        public int CcCCVNum { get => ccCCVNum; set => ccCCVNum = value; }

        public SDZooGiveOnceForm()
        {

        }

        public SDZooGiveOnceForm(int donationBtnNum, decimal customDonationAmt, string? firstName, 
            string? lastName1, string? email, string? streetOne, string? streetTwo, string? city,
            string? state, string? country, int ccNum, int ccExpDateMonthNum, int ccExpDateYearNum,
            int ccCCVNum)
        {
            DonationBtnNum = donationBtnNum;
            CustomDonationAmt = customDonationAmt;
            FirstName = firstName;
            LastName1 = lastName1;
            Email = email;
            StreetOne = streetOne;
            StreetTwo = streetTwo;
            City = city;
            State = state;
            Country = country;
            CcNum = ccNum;
            CcExpDateMonthNum = ccExpDateMonthNum;
            CcExpDateYearNum = ccExpDateYearNum;
            CcCCVNum = ccCCVNum;
        }
    }
}
