using Aquality.Selenium.Browsers;

namespace VkAPI.Tests
{
    public abstract class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            AqualityServices.Browser.Maximize();
            AqualityServices.Browser.GoTo("https://vk.com/");
            AqualityServices.Browser.WaitForPageToLoad();
        }

        [TearDown]
        public void TearDown()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
