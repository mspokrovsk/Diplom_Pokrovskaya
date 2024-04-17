using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;
using Diplom_Pokrovskaya.Pages;
using OpenQA.Selenium.Interactions;
using Diplom_Pokrovskaya.Steps;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [TestFixture]
    [AllureEpic("Web Interface")]
    [AllureFeature("Login feature", "AddProject feature")]
    public class FileUploadTest : BaseTest
    {
        [Test(Description = "Проверка на загрузку файла")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("Story5")]
        public void TestFileUpload()
        {
            UserSteps userSteps = new UserSteps(Driver);
            ProjectsPage projectsPage = userSteps.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectsPage.ClickAddToProject();
            projectsPage.ClickAddFile();
            Thread.Sleep(3000);
            Assert.That(projectsPage.AvatarUpload);
        }
    }
}
   