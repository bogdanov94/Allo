using Allo.Base.Helpers;
using OpenQA.Selenium;

namespace Allo.PageObjects.HtmlElements
{ 
    public class LoginDialogHtmlElement : BaseDialogHtmlElement
    {
        public LoginDialogHtmlElement(By condition) : base(condition)
        {
        }

        public LoginDialogHtmlElement(HtmlElement parent, By condition) : base(parent, condition)
        {
        }

        protected override HtmlElement CloseBtn 
            => new HtmlElement(By.CssSelector(".v-modal__close-btn"));

        public InputHtmlElement UserNameInput
            => new InputHtmlElement(By.CssSelector("#auth"));

        public InputHtmlElement PasswordInput
            => new InputHtmlElement(By.CssSelector("#v-login-password"));

        public HtmlElement SubmitBtn
            => new HtmlElement(By.CssSelector(".modal-submit-button"));
       
        public void CloseDialog()
        {
            WaitUntil.ConditionIsMet(x => CloseBtn.IsElementPresent());
            CloseBtn.Click();
            WaitUntil.ConditionIsMet(x => !CloseBtn.IsElementPresent());
        }
    }
}
