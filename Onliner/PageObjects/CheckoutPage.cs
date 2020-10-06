using System;
using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class CheckoutPage
    {
        private const string _paymentInfoButtonXpath = "//button[contains(text(),'Перейти к способу оплаты')]";

        [FindsBy(How = How.XPath, Using = _paymentInfoButtonXpath)] [CacheLookup]
        private IWebElement _paymentInfoButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Перейти к подтверждению заказа')]")] [CacheLookup]
        private IWebElement _confirmInfoButton;

        public void ConfirmOrder()
        {
            BrowserFactory.Driver.WaitForElement(By.XPath(_paymentInfoButtonXpath),40);
            Actions actions = new Actions(BrowserFactory.Driver);
            actions.MoveToElement(_paymentInfoButton).Click().Perform();
            _confirmInfoButton.Click();
        }
    }
}
