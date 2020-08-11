using OpenQA.Selenium;

namespace CloudinaryUITests.Pages.POM
{
    public class UploadWindow : PageBase<UploadWindow>
    {
        public UploadWindow(IWebDriver driver) : base(driver)
        {
            driver.SwitchTo().Frame(FrameUw);
        }


        #region WebElements

        private IWebElement FrameUw => commonDriver.FindElement(By.CssSelector("iframe[data-test='uw-iframe'"));
        private IWebElement ButtonAdvanced => commonDriver.FindElement(By.CssSelector("button[data-test='btn-advanced']"));
        private IWebElement InputPublicId => commonDriver.FindElement(By.CssSelector("input[data-test='public-id']"));
        private IWebElement ButtonBrowse => commonDriver.FindElement(By.CssSelector("input[name='file']"));

        #endregion


        #region Methods

        public UploadWindow clickAdvancedButton()
        {
            ButtonAdvanced.Click();
            return this;
        }
        
        public UploadWindow setInputId(string publicId)
        {
            InputPublicId.SendKeys(publicId);
            return this;
        }

        public MediaLibraryPage uploadFile(string filePath)
        {
            ButtonBrowse.SendKeys(filePath);
            return new MediaLibraryPage(commonDriver);
        }

        #endregion
    }
}
