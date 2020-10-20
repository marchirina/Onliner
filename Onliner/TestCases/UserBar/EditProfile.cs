using System.Configuration;
using NUnit.Framework;
using Onliner.PageObjects;

namespace Onliner.TestCases.UserBar
{
    public class EditProfile : BaseTest
    {
        [Test]
        public void CheckUserProfile()
        {
            Pages.Main.OpenEditProfilePage();
            Pages.Profile.SelectAgreementForParticipation();
            Assert.IsTrue(Pages.Profile.IsAgreementCheckboxSelected());
            Assert.AreEqual(ConfigurationManager.AppSettings["NICK"], Pages.Profile.GetNickNameText());
            Assert.AreEqual(ConfigurationManager.AppSettings["NAME"], Pages.Profile.GetNameText());
            Assert.AreEqual(ConfigurationManager.AppSettings["CITY"], Pages.Profile.GetCityText());
            Assert.AreEqual(ConfigurationManager.AppSettings["OCCUPATION"], Pages.Profile.GetOccupationText());
            Assert.AreEqual(ConfigurationManager.AppSettings["PHONE"], Pages.Profile.GetPhoneText());
            Assert.AreEqual(ConfigurationManager.AppSettings["EMAIL"], Pages.Profile.GetEmailText());
        }

        [TearDown]
        public void RemoveAgreementToParticipateCheckbox()
        {
            Pages.Profile.SelectAgreementForParticipation();
        }
    }
}
