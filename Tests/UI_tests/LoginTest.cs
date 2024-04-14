using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;
using Diplom_Pokrovskaya.Pages;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void LoginWithStandardUser()
        {
            LoginPage loginPage = new LoginPage(Driver);
            ProjectsPage projectsPage = loginPage.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

            Assert.That(projectsPage.IsPageOpened());
        }

        [Test]
        public void LoginWithErrorUsername()
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.IncorrectLogin("mspokrovsk@mts", Configurator.AppSettings.Password);
            loginPage.TextError.Text.Trim();
            Is.EqualTo("These credentials do not match our records or the user account is not allowed to log in");
        }
    }
}
   