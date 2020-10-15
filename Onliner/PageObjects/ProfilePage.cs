using Onliner.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class ProfilePage
    {
        [FindsBy(How = How.XPath, Using = "//label[contains(@class,'profile-form')][.//span[text()='Даю согласие на участие в ']]" +
                                          "//span[@class='i-checkbox__faux']")]
        private IWebElement _agreementForParticipationCheckbox;

        [FindsBy(How = How.XPath, Using = "//label[contains(@class,'profile-form')][.//span[text()='Даю согласие на участие в ']]//input")]
        private IWebElement _checkAgreementForParticipationCheckbox;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'form__group')][.//div[contains(text(),'Ник')]]//span[contains(@class,'form__hint')]")]
        private IWebElement _profileNickNameTextBox;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'form__group')][.//div[contains(text(),'ФИО')]]//span[contains(@class,'form__hint')]")]
        private IWebElement _profileNameTextBox;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'form__group')][.//div[contains(text(),'Из города')]]//span[contains(@class,'form__hint')]")]
        private IWebElement _profileCityTextBox;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'profile-form__group')][.//div[contains(text(),'Род занятий')]]" +
                                          "//span[contains(@class,'profile-form__hint')]")]
        private IWebElement _profileOccupationTextBox;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'link_primary-alter')]")]
        private IWebElement _profilePhoneTextBox;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'profile-form__group')][.//div[contains(text(),'E-mail')]]" +
                                          "//span[contains(@class,'profile-form__hint')]")]
        private IWebElement _profileEmailTextBox;

        public void SelectAgreementForParticipation()
        {
            JavaScriptHelper.ScrollToElement(_agreementForParticipationCheckbox);
            _agreementForParticipationCheckbox.Click();
        }

        public bool IsAgreementCheckboxSelected() => _checkAgreementForParticipationCheckbox.Selected;
        public string GetNickNameTextCoincide() => _profileNickNameTextBox.Text;
        public string GetNameTextCoincide() => _profileNameTextBox.Text;
        public string GetCityTextCoincide() => _profileCityTextBox.Text;
        public string GetOccupationTextCoincide() => _profileOccupationTextBox.Text;
        public string GetPhoneTextCoincide() => _profilePhoneTextBox.Text;
        public string GetEmailTextCoincide() => _profileEmailTextBox.Text;
    }
}
