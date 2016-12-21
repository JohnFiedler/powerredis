using System.Management.Automation;
using ServiceStack.Redis;
using System.Collections.Generic;
using System;



namespace PowerRedis2
{
    #region Server
    
    [Cmdlet(VerbsCommon.Get, "RedisInfo")]
    public class GetRedisInfoCommand : Cmdlet
    {
        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Dictionary<string, string> info = Globals.rc.Info;
            WriteObject(info);
        }

        protected override void EndProcessing()
        {

        }
    }

    #endregion

}
