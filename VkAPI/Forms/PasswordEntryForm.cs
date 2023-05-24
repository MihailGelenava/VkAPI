using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using VkAPI.TestsData;

namespace VkAPI.Forms
{
    public class PasswordEntryForm : Form
    {
        private ITextBox PasswordTextBox => ElementFactory.GetTextBox(By.Name("password"), "Password input field");
        private IButton ContinueButton => ElementFactory.GetButton(By.ClassName("vkuiButton__in"), "Confirm password button");
        public PasswordEntryForm() : base(By.Name("password"), "Password Entry form")
        {
        }
        public void EntryPassword() => PasswordTextBox.ClearAndType(VkTestData.Password);
        public void ConfirmPassword() => ContinueButton.Click();
    }
}
