using OpenQA.Selenium;
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

        // Инициализация класса
        public ProjectsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }


        // Методы
        public IWebElement PageTitle => WaitsHelper.WaitForExists(pageTitle);

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
    }
}
