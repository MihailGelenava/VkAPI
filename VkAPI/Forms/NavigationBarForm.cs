
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VkAPI.Forms
{
    public class NavigationBarForm : Form
    {
        private ILink MyProfileLink => ElementFactory.GetLink(By.Id("l_pr"),"MyProfile navigation link");

        public NavigationBarForm() : base(By.Id("side_bar"), "Navigation Side bar form")
        {
        }

        public void GoToMyProfile()=>MyProfileLink.Click();
    }
}
