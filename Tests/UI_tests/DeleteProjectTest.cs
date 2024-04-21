using Diplom_Pokrovskaya.Helpers.Configuration;
using Diplom_Pokrovskaya.Steps;
using Diplom_Pokrovskaya.Pages;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [AllureEpic("Web Interface")]
    [AllureFeature("Login feature", "AddProject feature", "DeleteProject")]

    public class DeleteProjectTest : BaseTest
    {
        [Test(Description = "ѕроверка успешного удалени€ созданного проекта")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("Story2")]
        public void TestDeleteProject()
        {
            UserSteps userSteps = new UserSteps(Driver);
            ProjectsPage projectsPage = userSteps.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            ProjectSteps projectSteps = new ProjectSteps(Driver);
            projectsPage = projectSteps.AddProject("Test_Project_Delete");
            projectsPage = projectSteps.DeleteProject(true);

            Assert.Multiple(() =>
            {
                Assert.That(projectsPage.IsPageOpened());
                Assert.That(projectsPage.IsNameProjectAbsent("Test_Project_Delete"));
            });
        }
    }
}
   