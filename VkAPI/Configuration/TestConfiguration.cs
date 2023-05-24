
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace VkAPI.Configuration
{
    public static class TestConfiguration
    {
        private static ISettingsFile TestConfigurationFile => new JsonSettingsFile("testConfig.json");

        public static string UserId => TestConfigurationFile.GetValue<string>("user_id");

    }
}
