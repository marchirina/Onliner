using NUnit.Framework;
using Onliner.PageObjects;
using Onliner.WrapperFactory;

namespace Onliner.TestCases
{
    public class BuyItems : BaseTest
    {
        [Test]
        public void BuyMacBook()
        {
            Pages.Main.GoToCatalogPage();
            Pages.Search.SearchItem("Apple MacBook Air 13 2020");
            Pages.Search.GoToItemPage("Ноутбук Apple MacBook Air 13");
            Pages.Item.AddItemInBasketForFirstExpandedShop();
            Pages.Main.GoToBasketPage();
            Pages.Basket.GoToCheckoutPage();
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
