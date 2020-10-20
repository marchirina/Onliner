using NUnit.Framework;
using Onliner.PageObjects;
using Onliner.PageObjects.Popups;


namespace Onliner.TestCases.Catalog
{
   public class CompareItems : BaseTest
    {
        [Test]
        public void ComparePhones()
        {
            Pages.Main.SearchItem("Iphone 11 64");
            Popups.Search.SelectComparisonItem("Смартфон Apple iPhone 11 Pro 64GB (серый космос)");
            Popups.Search.SelectComparisonItem("Смартфон Apple iPhone 11 64GB (фиолетовый)");
            Popups.Search.OpenComparePage();
            Assert.IsTrue(Pages.Compare.IsFirstPhoneBetter());
        }

        [TearDown]
        public void DeleteCompare()
        {
            Pages.Compare.ClearComparePage();
        }
    }
}
