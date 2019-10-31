using System.Management.Automation;
using System.Collections.Generic;
using ServiceStack.Redis;


namespace PowerRedis2
{
    #region Hashes

    //HSET
    [Cmdlet(VerbsCommon.Set, "RedisHashValue")]
    public class SetRedisHashCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
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
            
            Globals.rc.SetEntryInHash(this.Hash, this.Key, this.Value);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    //HSETNX
    [Cmdlet(VerbsCommon.Set, "RedisHashValueIfNotExists")]
    public class SetRedisHashNXCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
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
            Globals.rc.SetEntryInHashIfNotExists(this.Hash, this.Key, this.Value);
        }

        protected override void EndProcessing()
        {

        }
    }


    //HMGet
    [Cmdlet(VerbsCommon.Get, "RedisHashAll")]
    public class GetRedisHashAllCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetAllEntriesFromHash(this.Hash));
        }

        protected override void EndProcessing()
        {

        }
    }

    //HGET
    [Cmdlet(VerbsCommon.Get, "RedisHashValue")]
    public class GetRedisHashCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
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
            WriteObject(Globals.rc.GetValueFromHash(this.Hash,this.Key));
        }

        protected override void EndProcessing()
        {

        }
    }

    //HGETValues
    [Cmdlet(VerbsCommon.Get, "RedisHashValues")]
    public class GetRedisHashValuesCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string[] Key { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetValuesFromHash(this.Hash, this.Key));
        }

        protected override void EndProcessing()
        {

        }
    }

    //HKeys
    [Cmdlet(VerbsCommon.Get, "RedisHashKeys")]
    public class GetRedisHashKeysCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetHashKeys(this.Hash));
        }

        protected override void EndProcessing()
        {

        }
    }

    //HDel
    [Cmdlet(VerbsCommon.Remove, "RedisHashEntry")]
    public class RemoveRedisHashEntryCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
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
            WriteObject(Globals.rc.RemoveEntryFromHash(this.Hash,this.Key));
        }

        protected override void EndProcessing()
        {

        }
    }


    //HExits
    [Cmdlet(VerbsCommon.Get, "RedisHashExists")]
    public class GetRedisHashExistsCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
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
            WriteObject(Globals.rc.HashContainsEntry(this.Hash, this.Key));
        }

        protected override void EndProcessing()
        {

        }
    }


    //HIncrby
    [Cmdlet(VerbsCommon.Set, "RedisHashIncrement")]
    public class SetRedisHashIncrementCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int IncrementBy { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.IncrementValueInHash(this.Hash, this.Key, this.IncrementBy));
        }

        protected override void EndProcessing()
        {

        }
    }

    //Hlen
    [Cmdlet(VerbsCommon.Get, "RedisHashLength")]
    public class GetRedisHashLengthCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int IncrementBy { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.HLen(this.Hash));
        }

        protected override void EndProcessing()
        {

        }
    }

    //HMSet
    [Cmdlet(VerbsCommon.Set, "RedisHashValues")]
    public class SetRedisHashValuesCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }
        private string _Hash;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public IEnumerable<KeyValuePair<string,string>> KeyValuePair { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SetRangeInHash(_Hash, this.KeyValuePair);
        }

        protected override void EndProcessing()
        {

        }
    }

    #endregion

}
