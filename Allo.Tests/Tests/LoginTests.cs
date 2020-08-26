using Allo.Base.Models;
using Allo.PageObjects.BusinessActions;
using Allo.Tests.DataSource;
using NUnit.Framework;

namespace Allo.Tests.Tests
{
    //NOTE: Parallelizable required for parallel execution. ParallelScope mark how to paralyze https://github.com/nunit/docs/wiki/Parallelizable-Attribute 
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class LoginTests : UiTestBase
    {
        [Test, TestCaseSource(typeof(MainDataSource), nameof(MainDataSource.LoginCases))]
        public void ValidateSuccessLogin(User user)
        {
            var loginAction = new LoginAction();
            var homePageAction = loginAction.Authentication(user);

            Assert.AreEqual(user.FirstName, homePageAction.GetUserName());
        }
    }
}
