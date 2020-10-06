using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
   public class SearchPage
   {
       [FindsBy(How = How.XPath, Using = "//input[@class='fast-search__input']")] [CacheLookup]
       private IWebElement _searchElementTextBox;

       [FindsBy(How = How.XPath, Using = "//iframe[@class='modal-iframe']")] [CacheLookup]
       private IWebElement _searchFrame;

       [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Ноутбук Apple MacBook Air 13')]")] [CacheLookup]
       private IWebElement _macElement;

        public void SearchItem(string itemName)
        {
            _searchElementTextBox.SendKeys(itemName);
        }

        public void SwitchToItemPage()
        {
            BrowserFactory.Driver.SwitchTo().Frame(_searchFrame);
            _macElement.Click();
            BrowserFactory.Driver.SwitchTo().DefaultContent();
        }
    }
}
