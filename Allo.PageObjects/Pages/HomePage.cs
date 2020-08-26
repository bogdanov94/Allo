using Allo.PageObjects.HtmlElements;
using OpenQA.Selenium;

namespace Allo.PageObjects.Pages
{
    //NOTE: Example of page object
    public class HomePage
    {   
        public HtmlElement NameContainer => 
            new HtmlElement(By.CssSelector("#customer-header-menu .name-container"));

        public HtmlElement BuyBtn => new HtmlElement(By.CssSelector(".buy.small"));

        public InputHtmlElement SearchInput =>
            new InputHtmlElement(By.CssSelector("#search"));
        
       public ShopCartDialogHtmlElement ShopCartDialogHtmlElement 
           => new ShopCartDialogHtmlElement(By.CssSelector(".cart-popup"));
    }
}
