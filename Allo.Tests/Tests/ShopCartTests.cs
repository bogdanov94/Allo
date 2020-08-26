using Allo.Base.Models;
using Allo.PageObjects.BusinessActions;
using NUnit.Framework;

namespace Allo.Tests.Tests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class ShopCartTests : UiTestBase
    {
        [Test, TestCaseSource(typeof(DataSource.MainDataSource), nameof(DataSource.MainDataSource.ByGoodsDataSource))]
        public void AddItemToShopCart(User user, string itemName)
        {
            var loginAction = new LoginAction();
            var homePageAction = loginAction.Authentication(user);

            homePageAction.MakeSearchOfItem(itemName);
            homePageAction.AddItemToShopCart();

            Assert.IsTrue(homePageAction.IsShopCartDialogOpen(), "IsShopCartDialogOpen:");
            homePageAction.CloseShopCartDialogOpen();
        }
    }
}
