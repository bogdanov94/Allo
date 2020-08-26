using OpenQA.Selenium;

namespace Allo.PageObjects.HtmlElements
{
    public class BaseDialogHtmlElement : HtmlElement
    {
        public BaseDialogHtmlElement(By condition) : base(condition)
        {
        }

        public BaseDialogHtmlElement(HtmlElement parent, By condition) : base(parent, condition)
        {
        }

        protected virtual HtmlElement CloseBtn
            => new HtmlElement(By.CssSelector(".close_btn"));
    }
}
