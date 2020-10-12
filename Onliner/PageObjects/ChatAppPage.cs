using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
    public class ChatAppPage
    {
        private const string _sendMessageButtonLocator = "//div[contains(@class,'trigger_send')]";

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'js-message-input')]")]
        private IWebElement _messageTextBox;

        [FindsBy(How = How.XPath, Using = _sendMessageButtonLocator)]
        private IWebElement _sendMessageButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'chat-offers__item_primary')]//div[contains(@class,'js-message-content')]")]
        private IWebElement _chatMessageBox;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'details-item')]/div[contains(@class,'status_sent')]")]
        private IWebElement _chatMessageStatus;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Удалить (1)')]")]
        private IWebElement _deleteMessageButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Удалить у всех')]")]
        private IWebElement _deleteFromAllButton;

        public void SendMessage(string txtMessage)
        {
            _messageTextBox.SendKeys(txtMessage);
            BrowserFactory.Driver.WaitForElement(By.XPath(_sendMessageButtonLocator));
            Actions actions = new Actions(BrowserFactory.Driver);
            actions.MoveToElement(_sendMessageButton).Click().Perform();
        }

        public string CompareTxtMessage()
        {
            return _chatMessageBox.Text;
        }

        public bool IsStatusMessageSentDisplayed()
        {
            return _chatMessageStatus.Displayed;
        }

        public void DeleteChatMessage()
        {
            if (!_chatMessageStatus.Displayed) return;
            _chatMessageBox.Click();
            _deleteMessageButton.Click();
            _deleteFromAllButton.Click();
        }

    }
}
