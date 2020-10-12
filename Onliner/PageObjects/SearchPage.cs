using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
   public class SearchPage
   {
       [FindsBy(How = How.XPath, Using = "//input[@class='fast-search__input']")]
       private IWebElement _searchTextBox;

       [FindsBy(How = How.XPath, Using = "//iframe[@class='modal-iframe']")]
       private IWebElement _searchFrame;

       [FindsBy(How = How.XPath, Using = "//div[contains(@class,'compare-button__state_initial')]")]
       private IWebElement _compareProductsButton;

        public void SearchItem(string itemName)
        {
            _searchTextBox.SendKeys(itemName);
        }

        public void OpenItemPage(string itemName)
        {
            BrowserFactory.Driver.SwitchTo().Frame(_searchFrame);
            BrowserFactory.Driver.FindElement(By.XPath($"//a[contains(text(),'{itemName}')]")).Click();
            BrowserFactory.Driver.SwitchTo().DefaultContent();
        }

        public void SelectCompareItem(string itemName)
        {
            BrowserFactory.Driver.SwitchTo().Frame(_searchFrame);
            BrowserFactory.Driver.FindElement(By.XPath($"//a[contains(text(),'{itemName}')]/ancestor::div[contains(@class,'result__item')]" +
                                                       "//span[contains(@class,'i-checkbox')]")).Click();
            BrowserFactory.Driver.SwitchTo().DefaultContent();
        }

        public void OpenComparePage()
        {
            BrowserFactory.Driver.SwitchTo().Frame(_searchFrame);
            _compareProductsButton.Click();
            BrowserFactory.Driver.SwitchTo().DefaultContent();
        }
    }
}
