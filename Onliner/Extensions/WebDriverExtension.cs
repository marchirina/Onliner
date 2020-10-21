using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Onliner.Extensions
{
    public static class WebDriverExtension
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By by, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver,TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            wait.Until(d => d.FindElement(by).Displayed && d.FindElement(by).Enabled);

            return driver.FindElement(by);
        }
    }
}
