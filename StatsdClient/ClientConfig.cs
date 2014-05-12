using System;
using System.Configuration;

namespace StatsdClient
{
  /// <summary>
  /// Configuration Element for reading statsdClient settings from a .config file
  /// </summary>
  public class ClientConfigElement : ConfigurationElement
  {
    /// <summary>
    /// The hostname or IP address of the statsd server
    /// </summary>
    [ConfigurationProperty("host", IsRequired = true)]
    public string Host
    {
      get { return this["host"] as string; }
      set { this["host"] = value; }
    }

    /// <summary>
    /// The port statsd is listening on
    /// </summary>
    [ConfigurationProperty("port", IsRequired = true)]
    public int Port
    {
      get { return (int)this["port"]; }
      set { this["port"] = value; }
    }

    /// <summary>
    /// The prefix to prepend to all metrics
    /// </summary>
    [ConfigurationProperty("prefix", IsRequired = false, DefaultValue = "Test")]
    public string Prefix
    {
      get { return this["prefix"] as string; }
      set { this["prefix"] = value; }
    }

    /// <summary>
    /// The connection type (Udp/Tcp)
    /// </summary>
    [ConfigurationProperty("connType", IsRequired = false, DefaultValue = ConnectionType.Udp)]
    public ConnectionType ConnectionType
    {
      get { return (ConnectionType)Enum.Parse(typeof(ConnectionType), this["connType"].ToString()); }
      set { this["connType"] = value; }
    }

    /// <summary>
    /// Retry the connection if it fails (TCP only).
    /// </summary>
    [ConfigurationProperty("tcpRetryOnDisconnect", IsRequired = false, DefaultValue = true)]
    public bool RetryOnDisconnect
    {
      get { return (bool)this["tcpRetryOnDisconnect"]; }
      set { this["tcpRetryOnDisconnect"] = value; }
    }

    /// <summary>
    /// Retry Attempts
    /// </summary>
    [ConfigurationProperty("retryAttempts", IsRequired = false, DefaultValue = 3)]
    public int RetryAttempts
    {
      get { return (int)this["retryAttempts"]; }
      set { this["retryAttempts"] = value; }
    }

    /// <summary>
    /// Retry the connection if it fails (TCP only).
    /// </summary>
    [ConfigurationProperty("rethrowOnError", IsRequired = false, DefaultValue = false)]
    public bool RethrowOnError
    {
      get { return (bool)this["rethrowOnError"]; }
      set { this["rethrowOnError"] = value; }
    }
  }

  /// <summary>
  /// Configuration Section for reading statsdClient settings from a .config file
  /// </summary>
  public class ClientConfigSection : ConfigurationSection
  {
    /// <summary>
    /// The client configuration node
    /// </summary>
    [ConfigurationProperty("client")]
    public ClientConfigElement StatsdClientConfig
    {
      get { return this["client"] as ClientConfigElement; }
    }

    /// <summary>
    /// Gets the config section labeled statsd
    /// </summary>
    /// <returns>The config section's data</returns>
    public static ClientConfigSection GetConfigSection()
    {
      return (ClientConfigSection)ConfigurationManager.GetSection("statsd");
    }
  }

}
