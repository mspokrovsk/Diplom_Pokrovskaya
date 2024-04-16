using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;
using Diplom_Pokrovskaya.Pages;
using OpenQA.Selenium.Interactions;
using Diplom_Pokrovskaya.Steps;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    public class DialogWindowTest : BaseTest
    {
        [Test]
        public void TestDialogWindow()
        {
            UserSteps userSteps = new UserSteps(Driver);
            ProjectsPage projectsPage = userSteps.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectsPage.ClickAddToProject();
            Assert.That(projectsPage.DialogWindowOpened);
        }
    }
}
   