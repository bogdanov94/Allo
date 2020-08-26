using System;
using Allo.Base.Enums;
using Allo.Base.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Allo.Base.Driver
{
    public class DriverFactory
    {
        public RemoteWebDriver CreateDriver(DriverType type)
        {
            //NOTE: IsDriverRemote setting
            bool isRemote = bool.Parse(ConfigurationHelper.GetConfiguration()["DriverSettings:IsRemoteDriver"]);
            //NOTE: In case of remote we will use a url, in case of local just a path
            var driverPath = isRemote ? ConfigurationHelper.GetConfiguration()["DriverSettings:RemoteDriverUrl"] : "./";

            switch (type)
            {
                case DriverType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    //NOTE: Make window maximize (could make a mistake on server, Better to set resolution from config)
                    chromeOptions.AddArguments("--start-maximized");
                    //NOTE: Is not required, but guaranty that extension will not affect tests 
                    chromeOptions.AddArguments("--disable-extensions");
                    if (isRemote)
                    {
                        //NOTE: here put Capability for remote WebDriver
                        chromeOptions.AddAdditionalCapability("chrome", "80.0", true);
                        chromeOptions.AddAdditionalCapability("enableVNC", true);
                        chromeOptions.AddAdditionalCapability(CapabilityType.PlatformName, Platform.CurrentPlatform);

                        return new RemoteWebDriver(new Uri(driverPath), chromeOptions);
                    }
                    else
                        return new ChromeDriver(driverPath, chromeOptions);
                case DriverType.FireFOx:
                    var firefoxOptions = new FirefoxOptions();
                    //NOTE: Set similar as for chrome
                    return new FirefoxDriver(driverPath, firefoxOptions);
                default:
                    throw new NotImplementedException($"{type} Is not sported");
            }
        }
    }
}
