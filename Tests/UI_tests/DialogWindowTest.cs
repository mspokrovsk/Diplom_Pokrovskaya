using Diplom_Pokrovskaya.Helpers.Configuration;
using Diplom_Pokrovskaya.Pages;
using Diplom_Pokrovskaya.Steps;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [AllureEpic("Web Interface")]
    [AllureFeature("Login feature", "AddProject feature")]
    public class DialogWindowTest : BaseTest
    {
        [Test(Description = "Проверка отображения диалогового окна")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("Story4")]
        public void TestDialogWindow()
        {
            UserSteps userSteps = new UserSteps(Driver);
            ProjectsPage projectsPage = userSteps.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectsPage.ClickAddToProject();

            Assert.That(projectsPage.DialogWindowOpened);
        }
    }
}
   
