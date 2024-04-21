using Allure.NUnit.Attributes;
using Diplom_Pokrovskaya.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Reflection;

namespace Diplom_Pokrovskaya.Pages
{
    public class ProjectsPage : PageBase
    {
        private static string END_POINT = "";

        private static By pageTitle = By.ClassName("page-title__title");
        private static By addProjectButton = By.CssSelector("[data-target='home--index.addButton']");
        private static By hoverElement = By.CssSelector("[data-content='mspokrovsk']");
        private static By projectDialog = By.ClassName("dialog__border");
        private static By selectFileButton = By.CssSelector("[data-action='click->doSelectAvatar']");
        private static By fileInput = By.CssSelector("[data-target='fileInput']");
        private static By avatarJpg = By.XPath("//img[starts-with(@src,'https://mspokrovsk.testmo.net/attachments/view/')]");
        private static By summary = By.CssSelector("[data-target=\"note behavior--maxlength-counter.control\"]");
        private static By projectName = By.CssSelector("[data-target='name']");
        private static By addDemoProject = By.CssSelector("[data-target='addDemoProject']");
        private static By submitButton = By.CssSelector("[data-target='submitButton']");
        private static By nameProject = By.XPath("//a[contains(@href, 'mspokrovsk.testmo.net/projects/view') and contains(text(), 'Test_Project')]");
        private static By admin = By.CssSelector("[data-content='Admin']");

        public ProjectsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }

        public IWebElement PageTitle => WaitsHelper.WaitForExists(pageTitle);

        public Button AddProjectButton => new Button(Driver, addProjectButton);

        public IWebElement HoverElement => WaitsHelper.WaitForExists(hoverElement);

        public IWebElement ProjectDialog => WaitsHelper.WaitForExists(projectDialog);

        public IWebElement SelectFileButton => WaitsHelper.WaitForExists(selectFileButton);

        public IWebElement FileInput => WaitsHelper.WaitForExists(fileInput);

        public IWebElement AvatarJpg => WaitsHelper.WaitForExists(avatarJpg);

        public IWebElement Summary => WaitsHelper.WaitForExists(summary);

        public IWebElement ProjectName => WaitsHelper.WaitForExists(projectName);

        public Checkbox AddDemoProject => new Checkbox(Driver, addDemoProject);

        public Button SubmitButton => new Button(Driver, submitButton);

        public IWebElement NameProject => WaitsHelper.WaitForExists(nameProject);

        public Button Admin => new Button(Driver, admin);

        [AllureStep("Нажата кнопка добавления проекта")]
        public void ClickAddToProject() => AddProjectButton.Click();

        [AllureStep("Нажата кнопка подтверждения")]
        public ProjectsPage ClickSubmitButton()
        {
            SubmitButton.Click();
            Thread.Sleep(3000);
            return new ProjectsPage(Driver, true);
        }

        [AllureStep("Нажата кнопка Admin")]
        public AdminPage ClickAdmin()
        {
            Admin.Click();
            return new AdminPage(Driver, true);
        }
    
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

        [AllureStep("Отобразилось всплывающее сообщение")]
        public void HoverOverHoverElement()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(HoverElement).Perform();
        }

        public bool IsTooltipTextCorrect(string tooltipText, string expectedText)
        {
            if (tooltipText == expectedText)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Tooltip text is incorrect. Expected: " + expectedText + ", actual: " + tooltipText);
                return false;
            }
        }

        [AllureStep("Отобразилось диалоговое окно")]
        public bool DialogWindowOpened()
        {
            return ProjectDialog.Displayed;
        }

        [AllureStep("Нажата кнопка добавления файла")]
        public void ClickAddFile()
        {
            SelectFileButton.Click();
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(assemblyPath, "Resource", "Avatar.jpg");
            FileInput.SendKeys(filePath);
        }

        [AllureStep("Отображение аватара")]
        public bool AvatarUpload()
        {
            return AvatarJpg.Displayed;
        }

        public string GenerateRandomLetters(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void AddRandomLetters()
        {
            string randomLetters = GenerateRandomLetters(81);
            Summary.SendKeys(randomLetters);
        }

        public bool IsNameProjectAbsent(string text)
        {
            return !IsElementPresent(By.XPath($"//div[contains(text(), '{text}')]"));
        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                Driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
