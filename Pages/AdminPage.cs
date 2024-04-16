using Diplom_Pokrovskaya.Elements;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;


namespace Diplom_Pokrovskaya.Pages
{
    public class AdminPage : PageBase
    {
        private static string END_POINT = "admin/projects";

        // Описание элементов
        private static By pageTitle = By.ClassName("page-header__title");
        private static By delete = By.CssSelector("[data-action='delete']");
        private static By deleteProjectDialog = By.CssSelector("[data-target='title']");
        private static By checkbox = By.CssSelector("[data-target='confirmationLabel']");
        private static By deleteProject = By.CssSelector("[data-target='deleteButton']");
        // Инициализация класса
        public AdminPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }
        // Методы
        public IWebElement PageTitle => WaitsHelper.WaitForExists(pageTitle);
        public Button DeleteButton => new Button(Driver, delete);
        public IWebElement DeleteProjectDialog => WaitsHelper.WaitForExists(deleteProjectDialog);
        public Checkbox CheckboxSet => new Checkbox(Driver, checkbox);
        public Button DeleteProject => new Button(Driver, deleteProject);

        // Комплексные
        [AllureStep("Нажата кнопка корзины")]
        public void ClickDeleteButton() => DeleteButton.Click();
        [AllureStep("Выбран чек-бокс")]
        public void SetCheckbox(bool flag) => CheckboxSet.SetCheckbox();
        [AllureStep("Нажата кнопка удаления проекта")]
        public void ClickDeleteProject() => DeleteProject.Click();

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            try
            {
                return PageTitle.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }

}
