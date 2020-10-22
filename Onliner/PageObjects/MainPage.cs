using Onliner.Extensions;
using Onliner.WrapperFactory;
using Onliner.Helper;
using Onliner.PageObjects.Popups;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
   public class MainPage
   {
       private const string CatalogButtonLocator = "//a[@class='b-main-navigation__link']/span[contains(text(),'Каталог')]";
       private const string ChatIconLocator = "//div[@id='global-chat-app']";

       private IWebElement _searchTextBox => BrowserFactory.Driver.WaitForElement(By.XPath("//input[@class='fast-search__input']"));

       [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Вход')]")]
       private IWebElement _loginButton;

       [FindsBy(How = How.XPath, Using = "//div[@id='cart-desktop']/a")]
       private IWebElement _basketButton;

       [FindsBy(How = How.XPath, Using = "//div[contains(@class,'main-page-news')][./header//*[contains(text(),'Технологии')]]" +
                                         "//div[contains(@class,'main-page-grid')]//li[last()]/div")]
       private IWebElement _lastTechNewsElement;

       [FindsBy(How = How.XPath, Using = ChatIconLocator)]
       private IWebElement _chatIcon;

       [FindsBy(How = How.XPath, Using = "//a[@class = 'b-top-profile__settings']")]
        private IWebElement _editProfileButton;

       public void OpenLoginPage()
       {
           _loginButton.Click();
       }

       public SearchPopup SearchItem(string itemName)
       {
           _searchTextBox.SendKeys(itemName);

           return new SearchPopup();
       }

       public void OpenBasketPage()
       {
           _basketButton.Click();
       }

       public void SelectLatestTechnicalNews()
       {
           BrowserFactory.Driver.WaitForElement(By.XPath(CatalogButtonLocator));
           JavaScriptHelper.ScrollToElement(_lastTechNewsElement);
           _lastTechNewsElement.Click();
       }

       public bool IsChatItemDisplayed()
       {
           BrowserFactory.Driver.WaitForElement(By.XPath(ChatIconLocator));

           return _chatIcon.Displayed;
       }

       public void OpenChatAppPage(string personName)
       {
           WebDriverHelper.WaitAndClick(By.XPath(ChatIconLocator));
           BrowserFactory.Driver.FindElement(By.XPath($"//div[contains(text(),'{personName}')]")).Click();
       }

       public void OpenEditProfilePage()
       {
           WebDriverHelper.WaitAndClick(By.XPath("//div[contains(@class,'profile__item_arrow')]"));
           _editProfileButton.Click();
       }
    }
}
