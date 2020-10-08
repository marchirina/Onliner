using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class ItemPage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='product-aside__box']/a[contains(@class,'item-button')]")] [CacheLookup]
        private IWebElement _firstExpandedAddToCartButton;

        public void AddItemInBasketForFirstExpandedShop()
        {
            _firstExpandedAddToCartButton.Click();
        }
    }
}
