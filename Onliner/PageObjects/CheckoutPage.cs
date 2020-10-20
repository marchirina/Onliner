using Onliner.Helper;
using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class CheckoutPage
    {
        private const string PaymentInfoButtonLocator = "//button[contains(text(),'Перейти к способу оплаты')]";

        [FindsBy(How = How.XPath, Using = PaymentInfoButtonLocator)]
        private IWebElement _paymentInfoButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Перейти к подтверждению заказа')]")]
        private IWebElement _confirmInfoButton;

        public void ConfirmOrder()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(PaymentInfoButtonLocator),40);
            Actions actions = new Actions(BrowserFactory.Driver);
            actions.MoveToElement(_paymentInfoButton).Click().Perform();
            _confirmInfoButton.Click();
        }
    }
}
