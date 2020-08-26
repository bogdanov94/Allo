using OpenQA.Selenium;

namespace Allo.PageObjects.HtmlElements
{
    public class ShopCartDialogHtmlElement : HtmlElement
    {
        public ShopCartDialogHtmlElement(By condition) : base(condition)
        {
        }

        public ShopCartDialogHtmlElement(HtmlElement parent, By condition) : base(parent, condition)
        {
        }

        public HtmlElement ComeBackBtn => new HtmlElement(By.CssSelector(".comeback"));
    }
}
