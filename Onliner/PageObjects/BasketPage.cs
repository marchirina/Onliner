using Onliner.Helper;
using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class BasketPage
    {
        private const string CheckoutButtonLocator = "//a[contains(text(),'Оформить заказ')]";

        [FindsBy(How = How.XPath, Using = CheckoutButtonLocator)]
        private IWebElement _checkoutButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'part_remove')]//a[contains(@class,'button_remove')]")]
        private IWebElement _deleteOrderButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'part_remove')]/div[contains(@class,'cart-form__control')]")]
        private IWebElement _deleteActionArea;

        public void OpenCheckoutPage()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(CheckoutButtonLocator),40);
            Actions actions = new Actions(BrowserFactory.Driver);
            actions.MoveToElement(_checkoutButton).Click().Perform();
        }

        public void DeleteOrderFromBasket()
        {
            Actions actions = new Actions(BrowserFactory.Driver);
            actions.MoveToElement(_deleteActionArea).Perform();
            actions.MoveToElement(_deleteOrderButton).Click().Perform();
        }
    }
}
