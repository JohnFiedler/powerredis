using System.Management.Automation;
using System.Collections.Generic;
using ServiceStack.Redis;

namespace PowerRedis2
{
    //GET
    #region Strings
    [Cmdlet(VerbsCommon.Get, "RedisKey")]
    public class GetRedisKeyCommand : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position= 0)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null)); }
        }
        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.Get<string>(this.Key));
        }

        protected override void EndProcessing()
        {
            // Globals.rc.Dispose();
        }
    }

    //SET
    [Cmdlet(VerbsCommon.Set, "RedisKey")]
    public class SetRedisKeyCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.Set(this.Key, Value));
            }
            catch (RedisException ex)
            {
                WriteError(new ErrorRecord(ex, "Error setting key", ErrorCategory.NotSpecified, this.Key));
            }
        }

        protected override void EndProcessing()
        {

        }
    }

    //APPEND
    [Cmdlet(VerbsCommon.Set, "RedisAppend")]
    public class SetRedisAppendCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null)); }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.AppendToValue(this.Key, this.Value));
            }
            catch (RedisException ex)
            {
                WriteError(new ErrorRecord(ex, "Error appending key", ErrorCategory.NotSpecified, this.Key));
            }
        }

        protected override void EndProcessing()
        {

        }
    }

    //DECR
    [Cmdlet(VerbsCommon.Set, "RedisDecrement")]
    public class SetRedisDecrementCommand : Cmdlet
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
            try
            {
                WriteObject(Globals.rc.Decr(this.Key));
            }
            catch (RedisException ex)
            {
                WriteError(new ErrorRecord(ex, "Error decrementing key", ErrorCategory.NotSpecified, this.Key));
            }
        }

        protected override void EndProcessing()
        {

        }
    }

    //SET
    [Cmdlet(VerbsCommon.Set, "RedisDecrementBy")]
    public class SetRedisDecrementByCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int Value { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.DecrBy(this.Key, this.Value));
            }
            catch (RedisException ex)
            {
                WriteError(new ErrorRecord(ex, "Error decrementing key", ErrorCategory.NotSpecified, this.Key));
            }
        }

        protected override void EndProcessing()
        {

        }
    }

    //GETSET
    [Cmdlet(VerbsCommon.Get, "RedisGetSet")]
    public class SetRedisGetSetCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.GetAndSetValue(this.Key, this.Value));
            }
            catch (RedisException ex)
            {
                WriteError(new ErrorRecord(ex, "Error Getting and Setting key", ErrorCategory.NotSpecified, this.Key));
            }
        }

        protected override void EndProcessing()
        {

        }
    }

    //INCR
    [Cmdlet(VerbsCommon.Get, "RedisIncrement")]
    public class SetRedisIncrementCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));  }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.Incr(this.Key));
            }
            catch (RedisException ex)
            {
                WriteError(new ErrorRecord(ex, "Error incrementing key", ErrorCategory.NotSpecified, this.Key));
            }
        }

        protected override void EndProcessing()
        {

        }
    }

    //MGET (test this)
    [Cmdlet(VerbsCommon.Get, "RedisMGet")]
    public class SetRedisMGetCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public List<string> Key { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null)); }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.GetValues<string>(this.Key));
            }
            catch (RedisException ex)
            {
                WriteError(new ErrorRecord(ex, "Error MGETTing", ErrorCategory.NotSpecified, this.Key));
            }
        }

        protected override void EndProcessing()
        {

        }
    }

    //MSet
    [Cmdlet(VerbsCommon.Get, "RedisMSet")]
    public class SetRedisMSetCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Dictionary<string, string> Key { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null)); }
        }

        protected override void ProcessRecord()
        {
            try
            {
                Globals.rc.SetAll<string>(this.Key);
            }
            catch (RedisException ex)
            {
                WriteError(new ErrorRecord(ex, "Error with MSET", ErrorCategory.NotSpecified, this.Key));
            }
        }

        protected override void EndProcessing()
        {

        }
    }

    //getbit
    //getrange
    //msetnx
    //setbit
    //setex
    //setnx
    //setrange

    #endregion

}
