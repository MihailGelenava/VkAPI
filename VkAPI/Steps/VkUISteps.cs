using VkAPI.Forms;

namespace VkAPI.Steps
{
    public class VkUISteps
    {
        private SignInForm signInForm = new SignInForm();
        private PasswordEntryForm passwordEntryForm = new PasswordEntryForm();

        public void AuthorizeVk()
        {
            Assert.That(signInForm.State.IsDisplayed, "vk.com wasn't opened");

            signInForm.EnterLogin();
            signInForm.ConfirmLogin();

            passwordEntryForm.EntryPassword();
            passwordEntryForm.ConfirmPassword();
        }
    }
}
