using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
   public class MainPage
   {
       private const string _catalogButtonLocator = "//a[@class='b-main-navigation__link']/span[contains(text(),'Каталог')]";
       private const string _chatIconLocator = "//div[@id='global-chat-app']";
       private const string _profileImageLocator = "//div[contains(@class,'profile__item_arrow')]";

       [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Вход')]")]
       private IWebElement _loginButton;

       [FindsBy(How = How.XPath, Using = _catalogButtonLocator)]
       private IWebElement _catalogButton;

       [FindsBy(How = How.XPath, Using = "//div[@id='cart-desktop']/a")]
       private IWebElement _basketButton;

       [FindsBy(How = How.XPath, Using = "//h2/a[contains(text(),'Технологии')]")]
       private IWebElement _technicalNewsHeader;

       [FindsBy(How = How.XPath, Using = "//div[contains(@class,'main-page-news')][./header//*[contains(text(),'Технологии')]]" +
                                         "//div[contains(@class,'main-page-grid')]//li[last()]/div")]
       private IWebElement _lastTechNewsElement;

       [FindsBy(How = How.XPath, Using = _chatIconLocator)]
       private IWebElement _chatIcon;

       [FindsBy(How = How.XPath, Using = "//div[@class ='chat-offers']")]
       private IWebElement _chatPersonList;

       [FindsBy(How = How.XPath, Using = _profileImageLocator)]
        private IWebElement _profileImage;

        [FindsBy(How = How.XPath, Using = "//a[@title = 'Редактировать личные данные']")]
        private IWebElement _editProfileButton;

        public void OpenLoginPage()
        {
            _loginButton.Click();
        }

        public void OpenCatalogPage()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_catalogButtonLocator));
            _catalogButton.Click();
        }

        public void OpenBasketPage()
        {
            _basketButton.Click();
        }

        public void SelectLatestTechnicalNews()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_catalogButtonLocator));
            ((IJavaScriptExecutor)BrowserFactory.Driver).ExecuteScript("arguments[0].scrollIntoView();", _technicalNewsHeader);
            _lastTechNewsElement.Click();
        }

        public bool IsChatItemDisplayed()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_chatIconLocator));
            return _chatIcon.Displayed;
        }

        public void OpenChatAppPage(string personName)
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_chatIconLocator));
            _chatIcon.Click();
            Actions actions = new Actions(BrowserFactory.Driver);
            actions.MoveToElement(_chatPersonList).Perform();
            BrowserFactory.Driver.FindElement(By.XPath($"//div[contains(text(),'{personName}')]")).Click();
        }

        public void OpenEditProfilePage()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_profileImageLocator));
            _profileImage.Click();
            _editProfileButton.Click();
        }
    }
}
