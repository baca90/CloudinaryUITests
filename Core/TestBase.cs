using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using System.Reflection;

namespace CloudinaryUITests.Core
{
    public class TestBase 
    {
        public IWebDriver CommonDriver { get; private set; }

        [SetUp]
        protected void Initialize()
        {
            CommonDriver = GetChromeDriver();
        }

        [TearDown]
        protected void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotImageFormat extension = ScreenshotImageFormat.Png;
                string fileName = $"{TestContext.CurrentContext.Test.MethodName}_{DateTime.Now:MMddHHmmss}";
                string fullFilePath = $"{Path.Combine(MainConfig.testResultsOutputPath, fileName)}.{extension}";

                Directory.CreateDirectory(MainConfig.testResultsOutputPath);
                CommonDriver.TakeScreenshot().SaveAsFile($"{fullFilePath}", extension);
                TestContext.WriteLine($"Screenshot saved at {fullFilePath}");
            }
            CommonDriver.Quit();
        }

        private ChromeDriver GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("start-maximized");
            //options.AddArgument("no-sandbox");
            //options.AddArgument("disable-dev-shm-usage");
            //options.AddArgument("disable-extensions");
            options.AddAdditionalCapability("useAutomationExtension", true);

            ChromeDriver driver = new ChromeDriver(Path.GetDirectoryName(MainConfig.solutionPath), options, new TimeSpan(0, 0, 60));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Cookies.DeleteAllCookies();
            return driver;
        }
    }
}
