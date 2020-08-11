using CloudinaryUITests.Core;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;

namespace CloudinaryUITests.Pages.POM
{
    public class LoginPage : PageBase<LoginPage>
    {
        public static string url = MainConfig.coreSettings.URL + "/users/login";

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }


        #region WebElements
        
        private IWebElement InputEmail => commonDriver.FindElement(By.Id("user_session_email"));
        private IWebElement InputPassword => commonDriver.FindElement(By.Id("user_session_password"));
        private IWebElement ButtonSignIn => commonDriver.FindElement(By.Id("sign-in"));

        #endregion


        #region Methods

        public LoginPage setEmail(string email)
        {
            InputEmail.Clear();
            InputEmail.SendKeys(email);
            return this;
        } 
        
        public LoginPage setPassword(string pass)
        {
            InputPassword.Clear();
            InputPassword.SendKeys(pass);
            return this;
        }

        public LoginPage clickSignInButton()
        {
            ButtonSignIn.Click();
            return this;
        }        

        #endregion
    }
}
