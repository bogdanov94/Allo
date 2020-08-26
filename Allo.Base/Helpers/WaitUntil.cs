using System;
using Allo.Base.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Allo.Base.Helpers
{
    //NOTE: Base static wait
    public static class WaitUntil
    {
        public static void ConditionIsMet(Func<IWebDriver, IWebElement> action, int timeOut = 10)
        {
            var wait = new WebDriverWait(DriverManager.GetDriver(), TimeSpan.FromSeconds(timeOut));
            wait.Until(action);
        }

        public static void ConditionIsMet(Func<IWebDriver, bool> action, int timeOut = 10)
        {
            var wait = new WebDriverWait(DriverManager.GetDriver(), TimeSpan.FromSeconds(timeOut));
            wait.Until(action);
        }
    }
}
