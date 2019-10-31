using System.Management.Automation;
using System.Collections.Generic;
using System;
using System.Collections;
using ServiceStack.Redis;

namespace PowerRedis2
{
    //KEYS
    [Cmdlet(VerbsCommon.Search, "RedisKeys")]
    public class SearchRedisKeysCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Pattern { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            if (this.Pattern == null)
                this.Pattern = "*";
            
            List<string> info = Globals.rc.SearchKeys(this.Pattern);
            WriteObjects(info);
        }

        protected override void EndProcessing()
        {
            
        }

        protected void WriteObjects(IEnumerable objects)
        {
            foreach (var obj in objects)
            {
                WriteObject(obj);
            }
        }
    }

    //del
    [Cmdlet(VerbsCommon.Remove, "RedisKey")]
    public class RemoveRedisKeyCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string[] Keys { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.Del(this.Keys);
        }

        protected override void EndProcessing()
        {

        }
    }

    //exists
    [Cmdlet(VerbsCommon.Get, "RedisExists")]
    public class GetRedisExistsCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.Exists(this.Key);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {

        }
    }

    //expire
    [Cmdlet(VerbsCommon.Set, "RedisExpire")]
    public class SetRedisExpireCommand : Cmdlet
    {

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int Seconds { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.Expire(this.Key, this.Seconds);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {

        }

    }

    //expireat
    [Cmdlet(VerbsCommon.Set, "RedisExpiresAt")]
    public class SetRedisExpiresAtCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public DateTime ExpireAt { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.ExpireEntryAt(this.Key, this.ExpireAt);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    //randomkey
    [Cmdlet(VerbsCommon.Get, "RedisRandomKey")]
    public class GetRedisRandomKeyCommand : Cmdlet
    {
        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.RandomKey();
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    //rename
    [Cmdlet(VerbsCommon.Rename, "RedisKey")]
    public class RenameRedisKeyCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string From { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string To { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.Rename(this.From,this.To);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    //ttl
    [Cmdlet(VerbsCommon.Get, "RedisTTL")]
    public class GetRedisTTLCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.Ttl(this.Key);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    //Type
    [Cmdlet(VerbsCommon.Get, "RedisType")]
    public class GetRedisTypeCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position=0, ValueFromPipeline=true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.Type(this.Key);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    ////not implemented
    //move
    //object
    //persist
    //renamenx
    //sort    
    //eval

}
