using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
   public class MainPage
   {
       private const string _catalogButtonXpath = "//a[@class='b-main-navigation__link']/span[contains(text(),'Каталог')]";

       [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Вход')]")] [CacheLookup]
       private IWebElement _loginButton;

       [FindsBy(How = How.XPath, Using = _catalogButtonXpath)]
       [CacheLookup]
       private IWebElement _catalogButton;

       [FindsBy(How = How.XPath, Using = "//div[@id='cart-desktop']/a")] [CacheLookup]
       private IWebElement _basketButton;

       [FindsBy(How = How.XPath, Using = "//h2/a[contains(text(),'Технологии')]")] [CacheLookup]
       private IWebElement _technicalNewsHeader;

       [FindsBy(How = How.XPath, Using = "//div[contains(@class,'main-page-news')][./header//*[contains(text(),'Технологии')]]//div[contains(@class,'main-page-grid')]//li[last()]")]
       [CacheLookup]
       private IWebElement _lastTechNewsElement;

        public void GoToLoginPage()
        {
            _loginButton.Click();
        }

        public void GoToCatalogPage()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_catalogButtonXpath));
            _catalogButton.Click();
        }

        public void GoToBasketPage()
        {
            _basketButton.Click();
        }

        public void ChoiceLastTechnicalNews()
        {
            ((IJavaScriptExecutor)BrowserFactory.Driver).ExecuteScript("arguments[0].scrollIntoView();", _technicalNewsHeader);
            _lastTechNewsElement.Click();
        }
    }
}
