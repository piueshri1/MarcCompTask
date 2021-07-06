using MarcCompTask.Utilities;
using MarcCompTask.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using static MarcCompTask.Utilities.Helper;

namespace MarcCompTask.Pages
{
    class ChatPage
    {
        // private readonly SearchPage searchPage;
        private readonly ServiceDetailsPage serviceDetailPage;
        private readonly SearchPage searchPage;
        private readonly LogInPage logInPage;

        public ChatPage()
        {

            PageFactory.InitElements(CommonDriver.driver, this);
            logInPage = new LogInPage();
            searchPage = new SearchPage();
            serviceDetailPage = new ServiceDetailsPage();
        }

        //  #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//*[@id='chatTextBox']")]
        private IWebElement ChatTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSend']")]
        private IWebElement Send { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Hello I want to trade my skill']")]
        private IWebElement SentMessage { get; set; }

        //Read data from Excel
        private string chatmessage = ExcelLib.ReadData(1, "ChatMessage");


        //sending message to seller
        public void ChatWithSeller(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            searchPage.SearchSkillsByAllCategories(driver);
            searchPage.ClickSearchedSkill();
            serviceDetailPage.ValidateYouAreAtServiceDetailPage();
            serviceDetailPage.ClickChat();
            ValidateYouAreOnChatPage();
            EnterChatMessage(chatmessage);
            ClickSend();
            bool isMessageSent = ValidateMessageSent(chatmessage);
            Assert.IsTrue(isMessageSent);
        }

        public void EnterChatMessage(string chatmessage)
        {
            //enter message in chat text box
            ChatTextBox.SendKeys(chatmessage);

        }
        public void ClickSend()
        {
            //click send
            Send.Click();
        }

        public void ValidateYouAreOnChatPage()
        {
            bool isChatRoom = ChatTextBox.Displayed;
            Assert.IsTrue(isChatRoom);
        }

        public bool ValidateMessageSent(string chatmessage)
        {
            //validate message is sent to seller
            if (SentMessage.Text == chatmessage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
