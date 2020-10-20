using Onliner.WrapperFactory;
using OpenQA.Selenium;

namespace Onliner.Helper
{
    public static class FrameHelper
    {
        public static void SwitchToPopup(IWebElement element, By by)
        {
            BrowserFactory.Driver.SwitchTo().Frame(element);
            BrowserFactory.Driver.FindElement(by).Click();
            BrowserFactory.Driver.SwitchTo().DefaultContent();
        }
    }
}
