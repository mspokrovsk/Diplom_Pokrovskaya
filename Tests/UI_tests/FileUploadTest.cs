using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;
using Diplom_Pokrovskaya.Pages;
using OpenQA.Selenium.Interactions;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    public class FileUploadTest : BaseTest
    {
        [Test]
        public void TestFileUpload()
        {
            LoginPage loginPage = new LoginPage(Driver);
            ProjectsPage projectsPage = loginPage.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectsPage.ClickAddToProject();
            projectsPage.ClickAddFile();
            Assert.That(projectsPage.AvatarUpload);
        }
    }
}
   