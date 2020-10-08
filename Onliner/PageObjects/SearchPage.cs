using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
   public class SearchPage
   {
       [FindsBy(How = How.XPath, Using = "//input[@class='fast-search__input']")] [CacheLookup]
       private IWebElement _searchTextBox;

       [FindsBy(How = How.XPath, Using = "//iframe[@class='modal-iframe']")] [CacheLookup]
       private IWebElement _searchFrame;

       public void SearchItem(string itemName)
        {
            _searchTextBox.SendKeys(itemName);
        }

        public void GoToItemPage(string itemName)
        {
            BrowserFactory.Driver.SwitchTo().Frame(_searchFrame);
            BrowserFactory.Driver.FindElement(By.XPath("//a[contains(text(),'" + itemName + "')]")).Click();
            BrowserFactory.Driver.SwitchTo().DefaultContent();
        }
    }
}
