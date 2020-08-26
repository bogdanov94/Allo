using Allo.Base.Helpers;
using OpenQA.Selenium;

namespace Allo.PageObjects.HtmlElements
{
    public class InputHtmlElement : HtmlElement
    {
        public InputHtmlElement(By condition) : base(condition)
        {
        }

        public InputHtmlElement(HtmlElement parent, By condition) : base(parent, condition)
        {
        }

        public void ClearAndType(string value)
        {
            Element.Clear();
            Element.SendKeys(value);
            Logger.Info($"Element {Condition} was cleared and Set Value {value}");
        }
    }
}
