using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class ProfilePage
    {
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Даю согласие на участие в')]/ancestor::label//span[@class='i-checkbox__faux']")]
        private IWebElement _agreementForParticipationCheckbox;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Даю согласие на участие в')]/ancestor::label//input")]
        private IWebElement _checkAgreementForParticipationCheckbox;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Ник')]/ancestor::div[contains(@class,'profile-form__group')]" +
                                          "//span[contains(@class,'profile-form__hint')]")]
        private IWebElement _profileNickNameTextBox;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'ФИО')]/ancestor::div[contains(@class,'profile-form__group')]" +
                                          "//span[contains(@class,'profile-form__hint')]")]
        private IWebElement _profileNameTextBox;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Из города')]/ancestor::div[contains(@class,'profile-form__group')]" +
                                          "//span[contains(@class,'profile-form__hint')]")]
        private IWebElement _profileCityTextBox;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Род занятий')]/ancestor::div[contains(@class,'profile-form__group')]" +
                                          "//span[contains(@class,'profile-form__hint')]")]
        private IWebElement _profileOccupationTextBox;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'link_primary-alter')]")]
        private IWebElement _profilePhoneTextBox;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'E-mail')]/ancestor::div[contains(@class,'profile-form__group')]" +
                                          "//span[contains(@class,'profile-form__hint')]")]
        private IWebElement _profileEmailTextBox;

        public void SelectAgreementForParticipation()
        {
            ((IJavaScriptExecutor)BrowserFactory.Driver).ExecuteScript("arguments[0].scrollIntoView();", _agreementForParticipationCheckbox);
            _agreementForParticipationCheckbox.Click();
        }

        public bool IsCheckboxAgreementSelected()
        {
            return _checkAgreementForParticipationCheckbox.Selected;
        }

        public string IsNickNameCoincide()
        {
           return _profileNickNameTextBox.Text;
        }

        public string IsNameCoincide()
        {
            return _profileNameTextBox.Text;
        }

        public string IsCityCoincide()
        {
            return _profileCityTextBox.Text;
        }

        public string IsOccupationCoincide()
        {
            return _profileOccupationTextBox.Text;
        }

        public string IsPhoneCoincide()
        {
            return _profilePhoneTextBox.Text;
        }

        public string IsEmailCoincide()
        {
            return _profileEmailTextBox.Text;
        }
    }
}
