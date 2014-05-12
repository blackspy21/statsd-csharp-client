using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsdClient;

namespace StatsdClientTests
{
  [TestClass]
  public class ConfigTests
  {
    [TestMethod]
    public void TestReadingConfigFromFile()
    {
      var config = ClientConfigSection.GetConfigSection();
      Assert.AreEqual(config.StatsdClientConfig.Host, "127.0.0.1");
      Assert.AreEqual(config.StatsdClientConfig.Port, 8080);
      Assert.AreEqual(config.StatsdClientConfig.Prefix, "bob");
      Assert.AreEqual(config.StatsdClientConfig.ConnectionType, ConnectionType.Tcp);
      Assert.AreEqual(config.StatsdClientConfig.RetryOnDisconnect, false);
      Assert.AreEqual(config.StatsdClientConfig.RetryAttempts, 5);
      Assert.AreEqual(config.StatsdClientConfig.RethrowOnError, true);
    }
  }
}
