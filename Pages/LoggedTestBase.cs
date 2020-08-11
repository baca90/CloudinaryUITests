using CloudinaryUITests.Pages.POM;
using NUnit.Framework;

namespace CloudinaryUITests.Core
{
    public class LoggedTestBase : TestBase
    {
        [SetUp]
        public void LoggedSetUp()
        {
            CommonDriver.Navigate().GoToUrl(LoginPage.url);

            LoginPage loginPage = new LoginPage(CommonDriver);
            loginPage.acceptCookie()
                .setEmail(MainConfig.testSettings.DEFAULT_EMAIL)
                .setPassword(MainConfig.testSettings.DEFAULT_PASSWORD)
                .clickSignInButton();
        }
    }
}
