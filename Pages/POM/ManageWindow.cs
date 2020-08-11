using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudinaryUITests.Pages.POM
{
    public class ManageWindow : PageBase<ManageWindow>
    {
        public ManageWindow(IWebDriver driver) : base(driver)
        {

        }


        #region WebElements

        private IWebElement InputTitle => commonDriver.FindElement(By.CssSelector("input[data-test='item-title']"));
        private IWebElement UrlImagePreview => commonDriver.FindElement(By.CssSelector("div[data-test='asset-url']"));

        #endregion


        #region Methods

        public void assertManageWindowImage(string imageId)
        {
            commonWait.Until(ExpectedConditions.ElementIsVisible(By.Id("new-drill-down")));

            Assert.IsTrue(InputTitle.GetAttribute("value").Contains(imageId));
            Assert.IsTrue(UrlImagePreview.Text.Contains(imageId));
        }

        #endregion
    }
}
