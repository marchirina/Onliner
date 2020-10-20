using NUnit.Framework;
using Onliner.PageObjects;
using Onliner.PageObjects.Popups;
using Onliner.WrapperFactory;

namespace Onliner.TestCases.Catalog
{
    public class BuyItems : BaseTest
    {
        [Test]
        public void BuyMacBook()
        {
            Pages.Main.SearchItem("Apple MacBook Air 13 2020");
            Popups.Search.OpenItemPage("Ноутбук Apple MacBook Air 13");
            Pages.Item.AddItemInBasketForFirstExpandedShop();
            Pages.Main.OpenBasketPage();
            Pages.Basket.OpenCheckoutPage();
            Pages.Checkout.ConfirmOrder();
        }

        [TearDown]
        public void DeleteMacBookFromBasket()
        {
            BrowserFactory.GoBackToPage();
            Pages.Basket.DeleteOrderFromBasket();
        }
    }
}
