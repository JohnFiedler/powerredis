using System.Management.Automation;
using ServiceStack.Redis;
using System.Collections.Generic;
using System;

namespace PowerRedis2
{

    #region PUbSub
    //Subscribe
    [Cmdlet(VerbsCommon.Get, "RedisSubscribe")]
    public class SetRedisSubscribeCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Channel { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.Subscribe(this.Channel));
        }

        protected override void EndProcessing()
        {

        }
    }

    #endregion

}
