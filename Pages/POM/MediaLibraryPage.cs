using CloudinaryUITests.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;

namespace CloudinaryUITests.Pages.POM
{
    public class MediaLibraryPage : PageBase<MediaLibraryPage>
    {
        public static string url = MainConfig.coreSettings.URL + "/console/media_library/folders/home";

        public MediaLibraryPage(IWebDriver driver) : base(driver)
        {

        }


        #region WebElements

        private IWebElement ButtonUpload => commonDriver.FindElement(By.CssSelector("#cld-upload-button .btn-upload"));
        private IWebElement LabelDone => commonDriver.FindElement(By.CssSelector("div[data-test='done-place-holder']"));
        private IWebElement ElementNewestImage => commonDriver.FindElement(By.CssSelector("article[data-test='asset-card']"));
        private List<IWebElement> ElementsImages => commonDriver.FindElements(By.CssSelector("article[data-test='asset-card']")).ToList();
        private IWebElement ButtonImageManage => commonDriver.FindElement(By.CssSelector("button[data-test='action-manage-btn']"));

        #endregion


        #region Methods

        public UploadWindow clickUploadButton()
        {
            ButtonUpload.Click();
            return new UploadWindow(commonDriver);
        }

        public MediaLibraryPage assertUpload()
        {
            Assert.IsTrue(LabelDone.Displayed);
            return this;
        }

        public MediaLibraryPage assertImage(string imageId)
        {
            waitForDocumentReady();
            commonWait.Until(ExpectedConditions.TextToBePresentInElement(ElementNewestImage, imageId));

            Assert.IsTrue(ElementNewestImage.Displayed);
            Assert.IsTrue(ElementNewestImage.Text.Contains(imageId));

            return this;
        }

        public ManageWindow openManagePopup(int imageIndex=0)
        {
            action.MoveToElement(ElementsImages[imageIndex]).Build().Perform();
            ButtonImageManage.Click();
                
            return new ManageWindow(commonDriver);
        }

        #endregion
    }
}
