using System.Management.Automation;
using ServiceStack.Redis;


namespace PowerRedis2
{
    #region Connection
    [Cmdlet("Connect", "RedisServer")]
    public class ConnectRedisServerCommand : Cmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true)]
        public string RedisServer { get; set; } = "localhost";

        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = true)]
        public int Database { get; set; } = 0;

        protected override void ProcessRecord()
        {
            try
            {
                Globals.RedisManager = new RedisManagerPool(RedisServer);
                Globals.rc = (RedisClient) Globals.RedisManager.GetClient();
                Globals.IsConnected = true;
                WriteVerbose("Connected");
            }
            catch (RedisException ex)
            {
                Globals.IsConnected = false;
                WriteError(new ErrorRecord(ex, "Could not connect", ErrorCategory.NotSpecified, RedisServer));
            }
        }
    }

    [Cmdlet("Disconnect", "RedisServer")]
    public class DisconnectRedisServerCommand : Cmdlet
    {
        protected override void ProcessRecord()
        {
            Globals.rc.Dispose();
            Globals.RedisManager.Dispose();
            WriteVerbose("Disconnected");
        }
    }
    #endregion

}
