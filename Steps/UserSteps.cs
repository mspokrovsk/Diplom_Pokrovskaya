using Diplom_Pokrovskaya.Pages;
using OpenQA.Selenium;

namespace Diplom_Pokrovskaya.Steps
{
    public class UserSteps : BaseSteps
    {
        private LoginPage _loginPage;

        public UserSteps(IWebDriver driver) : base(driver)
        {
            _loginPage = new LoginPage(Driver);
        }

        public ProjectsPage SuccessfulLogin(string username, string password)
        {
            _loginPage.UsernameField.SendKeys(username);
            _loginPage.PasswordField.SendKeys(password);
            _loginPage.ClickLoginInButton();

            return new ProjectsPage(Driver, true);
        }

        public LoginPage IncorrectLogin(string username, string password)
        {
            _loginPage.UsernameField.SendKeys(username);
            _loginPage.PasswordField.SendKeys(password);
            _loginPage.ClickLoginInButton();

            return _loginPage;
        }
    }
}
