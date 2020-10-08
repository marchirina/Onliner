﻿using Onliner.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
   public class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static MainPage Home => GetPage<MainPage>();
        public static LogInPage Login => GetPage<LogInPage>();
        public static SearchPage Search => GetPage<SearchPage>();
        public static ItemPage Item => GetPage<ItemPage>();
        public static BasketPage Basket => GetPage<BasketPage>();
        public static CheckoutPage Checkout => GetPage<CheckoutPage>();
        public static NewsItemPage NewsItem => GetPage<NewsItemPage>();
    }
}