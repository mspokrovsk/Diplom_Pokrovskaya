using Diplom_Pokrovskaya.Helpers.Configuration;
using Diplom_Pokrovskaya.Helpers;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Pokrovskaya.Elements
{
    public class UIElement : IWebElement
    {

        private IWebDriver _webDriver; // Для хранения экземпляра веб-драйвера
        private WaitsHelper _waitsHelper; // Для работы с ожиданиями загрузки
        private IWebElement _webElement; // Для хранения веб-элемента
        private Actions _actions; // Для работы с действиями с веб-элементами

        private UIElement(IWebDriver webDriver) // Приватный конструктор класса UIElement, принимающий веб-драйвер в качестве параметра
        {
            _webDriver = webDriver;
            _waitsHelper = new WaitsHelper(webDriver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
            _actions = new Actions(webDriver);
        }

        public UIElement(IWebDriver webDriver, By by) : this(webDriver) //Публичный конструктор класса UIElement, принимающий веб-драйвер и локатор элемента By, инициализирующий объект UIElement через вызов основного конструктора
        {
            _webElement = _waitsHelper.WaitForExists(by);
        }

        public UIElement(IWebDriver webDriver, IWebElement webElement) : this(webDriver) //Публичный конструктор класса UIElement, принимающий веб-драйвер и веб-элемент, инициализирующий объект UIElement через вызов основного конструктора
        {
            _webElement = webElement;
        }

        public IWebElement FindElement(By by) //Метод для поиска и возвращения одного веб-элемента по локатору By
        {
            return _waitsHelper.WaitChildElement(_webElement, by);
        }

        public UIElement FindUIElement(By by) //Метод для поиска и возвращения нового объекта UIElement, используя метод FindElement
        {
            return new UIElement(_webDriver, FindElement(by));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by) //Метод для поиска и возвращения коллекции веб-элементов по локатору By
        {
            return _webElement.FindElements(by);
        }

        public List<UIElement> FindUIElements(By by) //Метод для поиска и возвращения коллекции новых объектов UIElement, используя метод FindElements
        {
            var result = new List<UIElement>();
            foreach (var webElement in FindElements(by))
            {
                result.Add(new UIElement(_webDriver, webElement));
            }

            return result;
        }

        public void Clear() //Очищает текстовое поле веб-элемента
        {
            _webElement.Clear();
        }

        public void SendKeys(string text)  //Вводит указанный текст в текстовое поле веб-элемента
        {
            _webElement.SendKeys(text);
        }

        public void Submit() //Отправляет форму, если веб-элемент является элементом формы
        {
            _webElement.Submit();
        }

        public void Click() //Выполняет клик по веб-элементу. В случае, если элемент не доступен для взаимодействия, использует дополнительные методы для выполнения клика
        {
            try
            {
                _webElement.Click();
            }
            catch (ElementNotInteractableException)
            {
                try
                {
                    _actions
                        .MoveToElement(_webElement)
                        .Click()
                        .Build()
                        .Perform();
                }
                catch (Exception)
                {
                    MoveToElement();
                    ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].click();", _webElement);
                }
            }
        }

        public string GetAttribute(string attributeName) //Возвращает значение указанного атрибута веб-элемента
        {
            return _webElement.GetAttribute(attributeName);
        }

        public string GetDomAttribute(string attributeName) //Возвращает значение указанного атрибута DOM веб-элемента
        {
            return _webElement.GetDomAttribute(attributeName);
        }

        public string GetDomProperty(string propertyName) //Возвращает значение указанного свойства DOM веб-элемента
        {
            return _webElement.GetDomProperty(propertyName);
        }

        public string GetCssValue(string propertyName) //Возвращает значение указанного CSS свойства веб-элемента
        {
            return _webElement.GetCssValue(propertyName);
        }

        public ISearchContext GetShadowRoot() //Возвращает корневой элемент теневого DOM веб-элемента, если он присутствует
        {
            return _webElement.GetShadowRoot();
        }

        public void MoveToElement() //Прокручивает страницу к указанному веб-элементу
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", _webElement);
        }

        public void Hover() //Выполняет наведение курсора на веб-элемент
        {
            _actions.MoveToElement(_webElement).Build().Perform();
        }

        public string TagName => _webElement.TagName; //Возвращает название тега веб-элемента

        public string Text //Возвращает текстовое содержимое веб-элемента. Логика определения текста может быть дополнительно настроена
        {
            get
            {
                /*
                if (_webElement.Text != null || _webElement.Text.Equals(""))
                {
                    if (GetAttribute("value").Equals(""))
                    {
                        return GetAttribute("innerText");
                    }

                    return GetAttribute("value");
                }
                */

                return _webElement.Text;
            }
        }

        public bool Enabled => _webElement.Enabled; //Возвращает информацию о доступности веб-элемента для взаимодействия
        public bool Selected => _webElement.Selected; //Возвращает информацию о выбранном состоянии веб-элемента
        public Point Location => _webElement.Location; //Возвращает координаты расположения веб-элемента на странице
        public Size Size => _webElement.Size; //Возвращает размеры веб-элемента
        public bool Displayed => _webElement.Displayed; //Проверяет, отображается ли веб-элемент на странице
    }
}