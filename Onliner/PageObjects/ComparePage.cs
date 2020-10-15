using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Onliner.PageObjects
{
    public class ComparePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'small button_gray')]")]
        private IWebElement _clearCompareButton;

        public bool IsFirstPhoneBetter()
        {
            var firstPhoneSpec = BrowserFactory.Driver.FindElements(By.XPath("//td[3][contains (@class,'cell_accent')]")).Count;
            var secondPhoneSpec = BrowserFactory.Driver.FindElements(By.XPath("//td[4][contains (@class,'cell_accent')]")).Count;

            return firstPhoneSpec > secondPhoneSpec;
        }

        public void ClearComparePage()
        {
            _clearCompareButton.Click();
        }
    }
}