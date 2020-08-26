using System;
using System.Collections.Generic;
using System.Linq;
using Allo.Base.Driver;
using Allo.Base.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace Allo.PageObjects.HtmlElements
{
    //NOTE: Base wrapper for IWebElement
    public class HtmlElement
    {
        protected RemoteWebDriver Driver = DriverManager.GetDriver();
        protected By Condition;
        protected HtmlElement Parent;

        public IWebElement Element => Parent != null
            ? Parent.Element.FindElement(Condition)
            : Driver.FindElement(Condition);

        //NOTE: Find element by locator
        public HtmlElement(By condition)
        {
            Condition = condition;
        }
        //NOTE: find element by locator inside other element
        public HtmlElement(HtmlElement parent, By condition)
        {
            Condition = condition;
            Parent = parent;
        }

        public string Id
        {
            get
            {
                var id = Element.GetAttribute("Id");
                Logger.Info($"Element {Condition} id sequel: {id}");
                return id;
            }
        }

        public string Text
        {
            get
            {
                var text = Element.Text;
                Logger.Info($"Element {Condition} text: {text}");
                return text;
            }
        }
        
        //NOTE: To find any type element inside other element 
        public T FindElement<T>(By by) where T : HtmlElement
        {
            return (T)Activator.CreateInstance(typeof(T), Element, by);
        }

        //NOTE: To find any type elementS inside other element 
        public List<T> FindElements<T>(By by) where T : HtmlElement
        {
            return Element.FindElements(by).Select(v => (T)Activator.CreateInstance(typeof(T), v)).ToList();
        }

        #region Main methods

        public bool IsElementPresent()
        {
            try
            {
                var a = Element.Enabled;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public void HoverOver()
        {
            Logger.Debug($"Element {Condition} was HoverOver");

            var action = new Actions(Driver);
            action.MoveToElement(Element).Perform();
        }

        public void Click()
        {
            Logger.Debug($"Element {Condition} was clicked");

            Element.Click();
        }

        public void DoubleClick()
        {
            Logger.Debug($"DoubleClick {Condition} was clicked");

            Element.Click();
            Element.Click();
        }
        #endregion
    }
}
