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

            Assert.That(projectsPage.IsPageOpened(), "”пс, элемент Projects не найден");
        }
    }
}
   