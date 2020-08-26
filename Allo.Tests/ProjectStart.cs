using Allo.Base.Helpers;
using NUnit.Framework;

//NOTE: LevelOfParallelism that show to the NUnit runner how much threads could be used simultaneously (max)
[assembly: LevelOfParallelism(4)]
namespace Allo.Tests
{
    [SetUpFixture]
    public class ProjectStart
    {
        //NOTE: It's a one time setup for whole project, run only once for execution 
        [OneTimeSetUp]
        public void ProjectSetUp()
        {
            //NOTE: this is required to start the logger first
            Logger.Init(nameof(ProjectStart));
        }

        //NOTE: It's a one time tearDown for whole project, run only once for execution 
        [OneTimeTearDown]
        public void ProjectTearDown()
        {
        }
    }
}
