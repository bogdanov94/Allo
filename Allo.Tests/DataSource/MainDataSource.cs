using System.Collections;
using Allo.Base.Models;
using NUnit.Framework;

namespace Allo.Tests.DataSource
{
    //NOTE: This is a example of dataSource, to implement DDT practice https://github.com/nunit/docs/wiki/TestCaseData
    public static class MainDataSource
    {
        public static IEnumerable LoginCases
        {
            get
            {
                //NOTE: TestCaseData is used to send data into TestMethod. Here could be simple data type and any objects
                yield return new TestCaseData(
                    new User()
                    {
                        FirstName = "YourName", 
                        LastName = "YourName", 
                        UserName = "PUTYOUREMAILHERE", 
                        UserPassword = "PUTYPURPASSWORDHERE"
                        //NOTE: SetName replace the test name. {m} in string just say to use the original TestMethod Name + special name for case 
                    }).SetName("{m}Test");
            }
        }

        public static IEnumerable ByGoodsDataSource
        {
            get
            {
                yield return new TestCaseData(
                    new User()
                    {
                        FirstName = "YourName",
                        LastName = "YourName",
                        UserName = "PUTYOUREMAILHERE",
                        UserPassword = "PUTYPURPASSWORDHERE"
                    }, "Холодильник").SetName("{m}RefrigeratorTest");

                yield return new TestCaseData(
                    new User()
                    {
                        FirstName = "YourName",
                        LastName = "YourName",
                        UserName = "PUTYOUREMAILHERE",
                        UserPassword = "PUTYPURPASSWORDHERE"
                    }, "Телефон").SetName("{m}CellPhoneTest");
            }
        }
    }
}
