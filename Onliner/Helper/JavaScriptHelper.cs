using Onliner.WrapperFactory;
using OpenQA.Selenium;

namespace Onliner.Helper
{
    public class JavaScriptHelper
    {
        public static void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)BrowserFactory.Driver).ExecuteScript("arguments[0].scrollIntoView();", element);
        }
    }
}
