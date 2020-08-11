using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace CloudinaryUITests.Pages
{
    public class PageBase<T> where T:PageBase<T>
    {
        protected IWebDriver commonDriver;
        protected WebDriverWait commonWait;
        protected IJavaScriptExecutor javaScriptExecutor;
        protected Actions action;

        public PageBase(IWebDriver driver)
        {
            commonDriver = driver;
            action = new Actions(commonDriver);
            javaScriptExecutor = (IJavaScriptExecutor)commonDriver;
            commonWait = new WebDriverWait(commonDriver, TimeSpan.FromSeconds(30));
        }


        #region WebElements

        private IWebElement ButtonAcceptCookie => commonDriver.FindElement(By.Id("CybotCookiebotDialogBodyButtonAccept"));

        #endregion


        #region Methods

        public T acceptCookie()
        {
            commonWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("CybotCookiebotDialog")));
            ButtonAcceptCookie.Click();

            return (T)this;
        }

        public T switchToDefaultContent()
        {
            commonDriver.SwitchTo().DefaultContent();

            return (T)this;
        }

        public void waitForDocumentReady()
        {
            commonWait.Until(x => javaScriptExecutor.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        #endregion
    }
}
