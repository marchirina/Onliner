using NUnit.Framework;
using Onliner.PageObjects;

namespace Onliner.TestCases.UserBar
{
    public class EditProfile : BaseTest
    {
        [Test]
        public void SelectAgreementToParticipate()
        {
            Pages.Main.OpenEditProfilePage();
            Pages.Profile.SelectAgreementForParticipation();
            Assert.IsTrue(Pages.Profile.IsCheckboxAgreementSelected());
            Assert.AreEqual("LeoDiCaprio", Pages.Profile.IsNickNameCoincide());
            Assert.AreEqual("DiCaprio Leonardo", Pages.Profile.IsNameCoincide());
            Assert.AreEqual("Los Angeles", Pages.Profile.IsCityCoincide());
            Assert.AreEqual("Actor", Pages.Profile.IsOccupationCoincide());
            Assert.AreEqual("+375 29 818 83 98", Pages.Profile.IsPhoneCoincide());
            Assert.AreEqual("marchenko_i@lwo.by", Pages.Profile.IsEmailCoincide());
        }

        [TearDown]
        public void RemoveAgreementToParticipateCheckbox()
        {
            Pages.Profile.SelectAgreementForParticipation();
        }
    }
}
