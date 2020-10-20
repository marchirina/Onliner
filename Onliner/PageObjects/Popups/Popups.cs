using Onliner.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects.Popups
{
    public class Popups
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static SearchPopup Search => GetPage<SearchPopup>();
    }
}
