using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class ItemPage
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'item--highlighted state')]//a[contains(@class,'button_orange')]")] [CacheLookup]
        private IWebElement _shopChoice;

        public void AddInBasket()
        {
            if (_shopChoice.Text == "В корзину")
            {
                _shopChoice.Click();
            }
        }
    }
}
