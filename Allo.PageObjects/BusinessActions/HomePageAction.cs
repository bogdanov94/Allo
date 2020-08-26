using Allo.Base.Helpers;
using Allo.PageObjects.Pages;
using OpenQA.Selenium;

namespace Allo.PageObjects.BusinessActions
{
    public class HomePageAction
    {
        public string GetUserName()
        {
            var homePage = new HomePage();

            return homePage.NameContainer.Text;
        }

        public void MakeSearchOfItem(string itemName)
        {
            var homePage = new HomePage();
            homePage.SearchInput.ClearAndType(itemName + Keys.Enter);

            WaitUntil.ConditionIsMet(x => homePage.BuyBtn.IsElementPresent());
        }

        public void AddItemToShopCart()
        {
            var homePage = new HomePage();
            homePage.NameContainer.HoverOver();

            homePage.BuyBtn.Click();
        }

        public bool IsShopCartDialogOpen()
        {
            var homePage = new HomePage();
            return homePage.ShopCartDialogHtmlElement.IsElementPresent();
        }

        public void CloseShopCartDialogOpen()
        {
            var homePage = new HomePage();
            homePage.ShopCartDialogHtmlElement.ComeBackBtn.Click();
        }
    }
}
