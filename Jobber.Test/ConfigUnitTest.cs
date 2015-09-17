using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobber.Test
{
    [TestClass]
    public class ConfigTest
    {
        [TestMethod]
        public void TestLoadConfigSingleFile()
        {
            var config = Config.Instance;
            config.Load("Data\\File copy task.xml");
            var job = JobManager.Instance.Get(new Guid("43B7FCF7-9156-462D-AB00-887C4B984294"));
            Assert.AreEqual(job.Id,new Guid("43B7FCF7-9156-462D-AB00-887C4B984294"));
        }

        [TestMethod]
        public void TestLoadConfigDirectory()
        {
            var config = Config.Instance;
            config.Load("Data");
        }
    }
}
