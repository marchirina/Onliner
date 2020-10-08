using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class BasketPage
    {
        private const string _checkoutButtonLocator = "//a[contains(text(),'Оформить заказ')]";

        [FindsBy(How = How.XPath, Using = _checkoutButtonLocator)] [CacheLookup]
        private IWebElement _checkoutButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'part_action')]//a[contains(@class,'button_remove')]")] [CacheLookup]
        private IWebElement _deleteOrderButton;

        public void GoToCheckoutPage()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_checkoutButtonLocator),40);
            Actions actions = new Actions(BrowserFactory.Driver);
            actions.MoveToElement(_checkoutButton).Click().Perform();
        }

        public void DeleteOrderFromBasket()
        {
            Actions actions = new Actions(BrowserFactory.Driver);
            actions.MoveToElement(_deleteOrderButton).Click().Perform();
        }
    }
}
