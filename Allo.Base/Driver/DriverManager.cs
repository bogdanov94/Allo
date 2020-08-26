using System;
using Allo.Base.Enums;
using Allo.Base.Helpers;
using OpenQA.Selenium.Remote;

namespace Allo.Base.Driver
{
    public static class DriverManager
    {
        //NOTE: ThreadStatic guaranty that _driver is isolated inside thread but as it static it is shared for whole project
        [ThreadStatic]
        private static RemoteWebDriver _driver;
        private static readonly object Lock = new object();

        //Method that return or create if null new driver
        public static RemoteWebDriver GetDriver()
        {
            //NOTE: If Driver was already created use it, others create new one
            if (_driver != null) return _driver;

            //NOTE: lock is required to guaranty correct behavior with parallel execution  
            lock (Lock)
            {
                //NOTE: The way to parse configuration string to enum type
                var driverType = Enum.Parse<DriverType>(ConfigurationHelper.GetConfiguration()["DriverSettings:DriverType"]);

                //NOTE: Create new instance of Driver
                _driver = new DriverFactory().CreateDriver(driverType);
            }

            return _driver;
        }

        //NOTE: Method that stop and close driver instance
        public static void StopDriver()
        {
            //NOTE: lock is required to guaranty correct behavior with parallel execution  
            lock (Lock)
            {
                _driver.Close();
                _driver.Quit();

                _driver = null;
            }
        }
    }
}
