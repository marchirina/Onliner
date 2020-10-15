using Onliner.WrapperFactory;
using OpenQA.Selenium;

namespace Onliner.Helper
{
    public class WebDriverHelper
    {
        public static void WaitAndClick(By by)
        {
           BrowserFactory.Driver.WaitForElement(by).Click();
        }
    }
}
