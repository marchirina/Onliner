using NUnit.Framework;
using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
   public class MainPage
   {
       private const string _catalogButtonLocator = "//a[@class='b-main-navigation__link']/span[contains(text(),'Каталог')]";
       private const string _chatIconLocator = "//div[@id='global-chat-app']";

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Вход')]")] [CacheLookup]
       private IWebElement _loginButton;

       [FindsBy(How = How.XPath, Using = _catalogButtonLocator)]
       [CacheLookup]
       private IWebElement _catalogButton;

       [FindsBy(How = How.XPath, Using = "//div[@id='cart-desktop']/a")] [CacheLookup]
       private IWebElement _basketButton;

       [FindsBy(How = How.XPath, Using = "//h2/a[contains(text(),'Технологии')]")] [CacheLookup]
       private IWebElement _technicalNewsHeader;

       [FindsBy(How = How.XPath, Using = "//div[contains(@class,'main-page-news')][./header//*[contains(text(),'Технологии')]]//div[contains(@class,'main-page-grid')]//li[last()]/div")]
       [CacheLookup]
       private IWebElement _lastTechNewsElement;

       [FindsBy(How = How.XPath, Using = _chatIconLocator)]
       [CacheLookup]
       private IWebElement _chatIcon;

        public void GoToLoginPage()
        {
            _loginButton.Click();
        }

        public void GoToCatalogPage()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_catalogButtonLocator));
            _catalogButton.Click();
        }

        public void GoToBasketPage()
        {
            _basketButton.Click();
        }

        public void SelectLatestTechnicalNews()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_catalogButtonLocator));
            ((IJavaScriptExecutor)BrowserFactory.Driver).ExecuteScript("arguments[0].scrollIntoView();", _technicalNewsHeader);
            _lastTechNewsElement.Click();
        }

        public void IsVisibleChatItem()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_chatIconLocator));
            Assert.IsTrue(_chatIcon.Displayed);
        }
    }
}
