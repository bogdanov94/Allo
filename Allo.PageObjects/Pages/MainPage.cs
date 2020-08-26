using Allo.PageObjects.HtmlElements;
using OpenQA.Selenium;

namespace Allo.PageObjects.Pages
{
    //NOTE: Example of page object
    public class MainPage
    {
        public LoginDialogHtmlElement LoginDialog
            => new LoginDialogHtmlElement(By.Id("customer-popup-menu"));

        public HtmlElement SignInLink
            => new HtmlElement(By.CssSelector("#customer-header-menu"));
    }
}
