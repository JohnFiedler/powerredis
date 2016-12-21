using System.Management.Automation;
using ServiceStack.Redis;


namespace PowerRedis2
{
    #region Connection
    [Cmdlet("Connect", "RedisServer")]
    public class ConnectRedisServerCommand : Cmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true)]
        public string RedisServer
        {
            get { return redisserver; }
            set { redisserver = value; }
        }
        private string redisserver = "localhost";

        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = true)]
        public int Database
        {
            get { return database; }
            set { database = value; }
        }
        private int database = 0;

        protected override void ProcessRecord()
        {
            try
            {
                Globals.rc = new RedisClient(redisserver);
                Globals.IsConnected = true;
                WriteVerbose("Connected");
            }
            catch
            {
                Globals.IsConnected = false;
                WriteObject("Could not connect");
            }
        }
    }

    [Cmdlet("Disconnect", "RedisServer")]
    public class DisconnectRedisServerCommand : Cmdlet
    {
        protected override void ProcessRecord()
        {
            Globals.rc.Dispose();
            WriteObject("Disconnected");
        }
    }
    #endregion

}
