using Onliner.Helper;
using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class ChatPage
    {
        private const string SendMessageButtonLocator = "//div[contains(@class,'trigger_send')]";

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'js-message-input')]")]
        private IWebElement _messageTextBox;

        [FindsBy(How = How.XPath, Using = SendMessageButtonLocator)]
        private IWebElement _sendMessageButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'chat-offers__item_primary')]//div[contains(@class,'js-message-content')]")]
        private IWebElement _chatMessageBox;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'details-item')]/div[contains(@class,'status_sent')]")]
        private IWebElement _chatMessageStatus;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'operation-item')][.//a[contains(text(),'Удалить')]]")]
        private IWebElement _deleteMessageButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Удалить у всех')]")]
        private IWebElement _deleteFromAllButton;

        public void SendMessage(string textMessage)
        {
            _messageTextBox.SendKeys(textMessage);
            BrowserFactory.Driver.WaitForElement(By.XPath(SendMessageButtonLocator));
            Actions actions = new Actions(BrowserFactory.Driver);
            actions.MoveToElement(_sendMessageButton).Click().Perform();
        }

        public bool IsMessageDisplayed(string textMessage) =>
            BrowserFactory.Driver.FindElement(By.XPath($"//div[contains(@class,'bubble_primary')][.//div[text()=\"{textMessage}\"]]" +
                                                        "//div[contains(@class,'status_sent')]")).Displayed;

        public void DeleteChatMessage()
        {
            if (_chatMessageStatus.Displayed)
            {
                _chatMessageBox.Click();
                _deleteMessageButton.Click();
                _deleteFromAllButton.Click();
            }
        }
    }
}
