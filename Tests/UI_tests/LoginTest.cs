using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;
using Diplom_Pokrovskaya.Pages;
using Diplom_Pokrovskaya.Steps;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void LoginWithStandardUser()
        {
            UserSteps userSteps = new UserSteps(Driver);
            ProjectsPage projectsPage = userSteps.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

            Assert.That(projectsPage.IsPageOpened);
        }

        [Test]
        public void LoginWithErrorUsername()
        {
            Assert.That(
            new UserSteps(Driver)
            .IncorrectLogin("mspokrovsk@mts", Configurator.AppSettings.Password)
            .GetErrorLabelText(),
            Is.EqualTo("These credentials do not match our records or the user account is not allowed to log in."));
        }
    }
}
   