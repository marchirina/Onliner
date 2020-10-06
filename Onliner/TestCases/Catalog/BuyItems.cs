using NUnit.Framework;
using Onliner.PageObjects;

namespace Onliner.TestCases
{
    public class BuyItems : BaseTest
    {
        [Test]
        public void BuyMacBook()
        {
            Pages.Home.GoToLoginPage();
            Pages.Login.LoginToPage();
            Pages.Home.GoToCatalogPage();
            Pages.Search.SearchItem("Apple MacBook Air 13 2020");
            Pages.Search.SwitchToItemPage();
            Pages.Item.AddInBasket();
            Pages.Home.GoToBasketPage();
            Pages.Basket.GoToCheckoutPage();
            Pages.Checkout.ConfirmOrder();
        }
    }
}
