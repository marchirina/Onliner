using System;
using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Onliner.Helper
{
    public static class WebDriverHelper
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By by, int timeoutInSeconds = 30)
        {
            var wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            wait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            wait.Until(d => d.FindElement(by).Displayed && d.FindElement(by).Enabled);
            return driver.FindElement(by);
        }

        public static void WaitAndClick(By by)
        {
            BrowserFactory.Driver.WaitForElement(by).Click();
        }
    }
}
