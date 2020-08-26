using Allo.Base.Helpers;
using Allo.Base.Models;
using Allo.PageObjects.Pages;

namespace Allo.PageObjects.BusinessActions
{
    public class LoginAction
    {
        public HomePageAction Authentication(User user)
        {
            var mainPage = new MainPage();
            mainPage.SignInLink.Click();

            var loginDialog = mainPage.LoginDialog;
            loginDialog.UserNameInput.ClearAndType(user.UserName);
            loginDialog.PasswordInput.ClearAndType(user.UserPassword);
            loginDialog.SubmitBtn.Click();

            var homePage = new HomePage();
            //NOTE: Example of Wait
            WaitUntil.ConditionIsMet(x => homePage.NameContainer.Text.Contains(user.FirstName), timeOut: 20);

            return new HomePageAction();
        }
    }
}
