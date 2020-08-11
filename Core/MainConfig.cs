using CloudinaryUITests.Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CloudinaryUITests.Core
{
    public class MainConfig
    {
        public static string solutionPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory,"../../../"));
        public static CoreSettingsModel coreSettings = new CoreSettingsModel();
        public static TestSettingsModel testSettings = new TestSettingsModel();
        public static string testResultsOutputPath;

        private static IConfiguration config;

        static MainConfig()
        {
            InitConfiguration();
            SetCoreSettings();
            SetTestSettings();
        }

        private static void InitConfiguration()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(solutionPath)
                .AddJsonFile("testSettings.JSON", optional: false, reloadOnChange: true)
                .Build();
        }

        private static void SetTestSettings()
        {
            config.GetSection("CLOUDINARY_TEST_SETTINGS").Bind(testSettings); 
        }

        private static void SetCoreSettings()
        {
            config.GetSection("CLOUDINARY_CORE_SETTINGS").Bind(coreSettings);
            testResultsOutputPath = Path.Combine(solutionPath, coreSettings.OUTPUT_PATH);
        }
    }
}
