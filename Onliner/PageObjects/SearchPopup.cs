using System.Threading;
using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class SearchPopup : BasePopup
    {
        [FindsBy(How = How.XPath, Using = "//iframe[@class='modal-iframe']")]
        private IWebElement _searchFrame;


        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'compare-button__state_initial')]")]
        private IWebElement _compareProductsButton;

        public SearchPopup() : base("//div[@id='fast-search-modal']")
        {
        }

        public void OpenItemPage(string itemName)
        {
            BrowserFactory.Driver.SwitchTo().Frame(_searchFrame);
            BrowserFactory.Driver.FindElement(By.XPath($"//a[contains(text(),'{itemName}')]")).Click();
            BrowserFactory.Driver.SwitchTo().DefaultContent();
        }

        public void SelectComparisonItem(string itemName)
        {
            BrowserFactory.Driver.SwitchTo().Frame(_searchFrame);
            BrowserFactory.Driver.FindElement(By.XPath($"//div[contains(@class,'product')][.//a[text()='{itemName}']]" +
                                                        "//span[contains(@class,'checkbox_yellow')]")).Click();
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
