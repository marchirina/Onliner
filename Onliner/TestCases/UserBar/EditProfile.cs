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
            Assert.AreEqual(ConfigurationManager.AppSettings["NICK"], Pages.Profile.GetNickNameTextCoincide());
            Assert.AreEqual(ConfigurationManager.AppSettings["NAME"], Pages.Profile.GetNameTextCoincide());
            Assert.AreEqual(ConfigurationManager.AppSettings["CITY"], Pages.Profile.GetCityTextCoincide());
            Assert.AreEqual(ConfigurationManager.AppSettings["OCCUPATION"], Pages.Profile.GetOccupationTextCoincide());
            Assert.AreEqual(ConfigurationManager.AppSettings["PHONE"], Pages.Profile.GetPhoneTextCoincide());
            Assert.AreEqual(ConfigurationManager.AppSettings["EMAIL"], Pages.Profile.GetEmailTextCoincide());
        }

        [TearDown]
        public void RemoveAgreementToParticipateCheckbox()
        {
            Pages.Profile.SelectAgreementForParticipation();
        }
    }
}
