using NUnit.Framework;
using Onliner.PageObjects;


namespace Onliner.TestCases.Catalog
{
   public class CompareItems : BaseTest
    {
        [Test]
        public void ComparePhones()
        {
            Pages.Main.OpenCatalogPage();
            Pages.Search.SearchItem("Iphone 11 64");
            Pages.Search.SelectCompareItem("Смартфон Apple iPhone 11 Pro 64");
            Pages.Search.SelectCompareItem("Смартфон Apple iPhone 11 64");
            Pages.Search.OpenComparePage();
            Assert.IsTrue(Pages.Compare.IsFirstPhoneBetter());
        }

        [TearDown]
        public void DeleteCompare()
        {
            Pages.Compare.ClearComparePage();
        }
    }
}
