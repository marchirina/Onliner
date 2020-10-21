using Onliner.Extensions;
using Onliner.Helper;
using Onliner.WrapperFactory;
using OpenQA.Selenium;

namespace Onliner.PageObjects.Popups
{
    public class SearchPopup : BasePopup
    {
        private const string CompareProductsButtonLocator = "//div[contains(@class,'compare-button__state_initial')]";
        private IWebElement SearchFrame => BrowserFactory.Driver.WaitForElement(By.XPath($"{PopupXpath}//iframe[@class='modal-iframe']"));

        public SearchPopup() : base("//div[@id='fast-search-modal']")
        {
        }

        public void OpenItemPage(string itemName)
        {
            FrameHelper.SwitchToPopupAndClick(SearchFrame, By.XPath($"//a[contains(text(),'{itemName}')]"));
        }

        public void SelectComparisonItem(string itemName)
        {
            FrameHelper.SwitchToPopupAndClick(SearchFrame, By.XPath($"//div[contains(@class,'product')][.//a[text()='{itemName}']]" +
                                                                    "//span[contains(@class,'checkbox_yellow')]"));
        }

        public void OpenComparePage()
        {
            FrameHelper.SwitchToPopupAndClick(SearchFrame, By.XPath(CompareProductsButtonLocator));
        }
    }
}
