using Diplom_Pokrovskaya.Pages;
using OpenQA.Selenium;

namespace Diplom_Pokrovskaya.Steps
{
    public class ProjectSteps : BaseSteps
    {
        private ProjectsPage _projectsPage;
        private AdminPage _adminPage;

        public ProjectSteps(IWebDriver driver) : base(driver)
        {
            _projectsPage = new ProjectsPage(Driver, true);
            _adminPage = new AdminPage(Driver, false);

        }

        public ProjectsPage AddProject(string projectname)
        {
            _projectsPage.ClickAddToProject();
            _projectsPage.ProjectName.SendKeys(projectname);
            _projectsPage.ClickSubmitButton();

            return new ProjectsPage(Driver, true);
        }

        public ProjectsPage DeleteProject(bool flag)
        {
            _projectsPage.ClickAdmin();
            _adminPage.ClickDeleteButton();
            _adminPage.SetCheckbox(flag);
            _adminPage.ClickDeleteProject();

            return new ProjectsPage(Driver, true);
        }
    }
}
