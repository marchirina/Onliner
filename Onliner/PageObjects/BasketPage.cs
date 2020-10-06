using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class BasketPage
    {
        private const string _checkoutButtonXpath = "//a[contains(text(),'Оформить заказ')]";

        [FindsBy(How = How.XPath, Using = _checkoutButtonXpath)] [CacheLookup]
        private IWebElement _checkoutButton;

        public void GoToCheckoutPage()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_checkoutButtonXpath),40);
            Actions actions = new Actions(BrowserFactory.Driver);
            actions.MoveToElement(_checkoutButton).Click().Perform();
        }
    }
}
