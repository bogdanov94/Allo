using System;
using Allo.Base.Driver;
using Allo.Base.Helpers;
using NUnit.Framework;

namespace Allo.Tests
{
    public class UiTestBase
    {
        //NOTE: This SetUp runs after each test
        [SetUp]
        public void SetUp()
        {
            //NOTE: ReInit logger, this will create new log file for each test   
            Logger.Init(TestContext.CurrentContext.Test.Name);
            //NOTE: Setup ImplicitWait
            DriverManager.GetDriver().Manage().Timeouts().ImplicitWait 
                = TimeSpan.FromSeconds(int.Parse(ConfigurationHelper.GetConfiguration()["SeleniumSettings:DefaultTimeOut"]));
            //NOTE: Get driver and GoToUrl that is described in settings file
            DriverManager.GetDriver().Navigate().GoToUrl(ConfigurationHelper.GetConfiguration()["Env:BaseUrl"]);
        }

        //NOTE: This tearDown runs after each test
        [TearDown]
        public void TearDown()
        {
            //NOTE: Stop Driver will close all browsers windows and exit from driver after test is finished
            DriverManager.StopDriver();
        }

        //NOTE: OneTimeSetUp for test class, runs once for a class (like LoginTests.cs)
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        //NOTE: OneTimeTearDown for test class, runs once for a class (like LoginTests.cs)
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }
    }
}