using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace VkAPI.TestsData
{
    public class VkTestData
    {
        private static ISettingsFile TestDataFile => new JsonSettingsFile("testData.json");

        public static string Password => TestDataFile.GetValue<string>("password");
        public static string Login => TestDataFile.GetValue<string>("login");
    }
}
