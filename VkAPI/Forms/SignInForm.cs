
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using VkAPI.TestsData;

namespace VkAPI.Forms
{
    public class SignInForm : Form
    {
        private ITextBox LoginTextBox => ElementFactory.GetTextBox(By.Id("index_email"), "Login input field");
        private IButton SignInButton => ElementFactory.GetButton(By.XPath("//button[contains(@class,'VkIdForm__signInButton')]"), "Sign In button");
        public SignInForm() : base(By.Id("index_email"), "SignIn form")
        {
        }
        public void EnterLogin() => LoginTextBox.ClearAndType(VkTestData.Login);
        public void ConfirmLogin() => SignInButton.Click();
    }
}
