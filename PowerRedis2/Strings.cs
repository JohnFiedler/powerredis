using System.Management.Automation;
using System.Collections.Generic;


namespace PowerRedis2
{
    //GET
    #region Strings
    [Cmdlet(VerbsCommon.Get, "RedisKey")]
    public class GetRedisKeyCommand : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position= 0)]
        [ValidateNotNullOrEmpty]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.Get<string>(key));
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
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private string _value;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.Set(key, Value));
            }
            catch
            {
                WriteObject(false);
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
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private string _value;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.AppendToValue(key, val));
            }
            catch
            {
                WriteObject(false);
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
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.Decr(key));
            }
            catch
            {
                WriteObject(false);
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
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int Val
        {
            get { return val; }
            set { val = value; }
        }
        private int val;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.DecrBy(key, val));
            }
            catch
            {
                WriteObject(false);
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
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Val
        {
            get { return _value; }
            set { _value = value; }
        }
        private string _value;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.GetAndSetValue(key, val));
            }
            catch
            {
                WriteObject(false);
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
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.Incr(key));
            }
            catch
            {
                WriteObject(false);
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
        public List<string> Key
        {
            get { return key; }
            set { key = value; }
        }
        private List<string> key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            try
            {
                WriteObject(Globals.rc.GetValues<string>(key));
            }
            catch
            {
                WriteObject(false);
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
        public Dictionary<string, string> Key
        {
            get { return key; }
            set { key = value; }
        }
        private Dictionary<string, string> key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            try
            {
                Globals.rc.SetAll<string>(key);
            }
            catch
            {
                WriteObject(false);
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
