using CloudinaryUITests.Core;
using CloudinaryUITests.Pages.POM;
using NUnit.Framework;
using System.IO;

namespace CloudinaryUITests
{
    public class Tests : LoggedTestBase
    {
        [Test]
        public void UploadImage()
        {
            string imageId = Faker.Name.First();
            CommonDriver.Navigate().GoToUrl(MediaLibraryPage.url);

            MediaLibraryPage mediaLibraryPage = new MediaLibraryPage(CommonDriver);
            mediaLibraryPage.clickUploadButton()
                .clickAdvancedButton()
                .setInputId(imageId)
                .uploadFile(Path.Combine(MainConfig.solutionPath, $"Resources/sample.jpg"))
                .assertUpload()
                .switchToDefaultContent()
                .assertImage(imageId)
                .openManagePopup()
                .assertManageWindowImage(imageId);
        }
    }
}