using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Pokrovskaya.Pages
{
    internal class ProjectsPage : PageBase
    {
        private static string END_POINT = "";

        // Описание элементов
        private static By pageTitle = By.ClassName("page-title__title");
        private static By addProjectButton = By.CssSelector("[data-action='click->home--index#doAddProject']");
        private static By hoverElement = By.CssSelector("[data-content='mspokrovsk']");
        

        // Инициализация класса
        public ProjectsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }


        // Методы
        public IWebElement PageTitle => WaitsHelper.WaitForExists(pageTitle);
        public IWebElement AddProjectButton => WaitsHelper.WaitForExists(addProjectButton);
        public IWebElement HoverElement => WaitsHelper.WaitForExists(hoverElement);

        // Комплексные
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
    }
}
