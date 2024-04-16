using OpenQA.Selenium;
using Diplom_Pokrovskaya.Helpers.Configuration;
using Diplom_Pokrovskaya.Elements;
using Diplom_Pokrovskaya.Steps;
using Diplom_Pokrovskaya.Pages;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    public class DeleteProjectTest : BaseTest
    {
        [Test]
        public void TestDeleteProject()
        {
            UserSteps userSteps = new UserSteps(Driver);
            ProjectsPage projectsPage = userSteps.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            ProjectSteps projectSteps = new ProjectSteps(Driver);
            projectsPage = projectSteps.AddProject("Test_Project");
            projectsPage = projectSteps.DeleteProject(true);
            //Thread.Sleep(3000);
            Assert.That(projectsPage.IsPageOpened());
            Assert.That(projectsPage.IsNameProjectAbsent("Test_Project"));
        }
    }
}
   