using Onliner.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects.Popups
{
    public class SearchPopup : BasePopup
    {
        private const string CompareProductsButtonLocator = "//div[contains(@class,'compare-button__state_initial')]";

        [FindsBy(How = How.XPath, Using = "//iframe[@class='modal-iframe']")]
        private IWebElement _searchFrame;

        public SearchPopup() : base("//div[@id='fast-search-modal']")
        {
        }

        public void OpenItemPage(string itemName)
        {
            FrameHelper.SwitchToPopupAndClick(_searchFrame, By.XPath($"//a[contains(text(),'{itemName}')]"));
        }

        public void SelectComparisonItem(string itemName)
        {
            FrameHelper.SwitchToPopupAndClick(_searchFrame, By.XPath($"//div[contains(@class,'product')][.//a[text()='{itemName}']]" +
                                                                     "//span[contains(@class,'checkbox_yellow')]"));
        }

        public void OpenComparePage()
        {
            FrameHelper.SwitchToPopupAndClick(_searchFrame, By.XPath(CompareProductsButtonLocator));
        }
    }
}
