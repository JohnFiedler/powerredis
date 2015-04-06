using System.Management.Automation;
using ServiceStack.Redis;
using System.Collections.Generic;
using System;


namespace PowerRedis2
{
    #region Hashes

    //HSET
    [Cmdlet(VerbsCommon.Set, "RedisHashValue")]
    public class SetRedisHashCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }
        private string _Hash;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private string _Value;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            
            Globals.rc.SetEntryInHash(_Hash, _Key, _Value);
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
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }
        private string _Hash;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private string _Value;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SetEntryInHashIfNotExists(_Hash, _Key, _Value);
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
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }
        private string _Hash;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetAllEntriesFromHash(_Hash));
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
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }
        private string _Hash;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetValueFromHash(_Hash,_Key));
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
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }
        private string _Hash;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string[] Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string[] _Key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetValuesFromHash(_Hash, _Key));
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
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }
        private string _Hash;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetHashKeys(_Hash));
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
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }
        private string _Hash;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.RemoveEntryFromHash(_Hash,_Key));
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
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }
        private string _Hash;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.HashContainsEntry(_Hash, _Key));
        }

        protected override void EndProcessing()
        {

        }
    }


    //HIncrby
    [Cmdlet(VerbsCommon.Set, "RedisHashIncrement")]
    public class SetRedisHashIncrCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }
        private string _Hash;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int IncrementBy
        {
            get { return _IncrementBy; }
            set { _IncrementBy = value; }
        }
        private int _IncrementBy;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.IncrementValueInHash(_Hash, _Key, _IncrementBy));
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
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }
        private string _Hash;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int IncrementBy
        {
            get { return _IncrementBy; }
            set { _IncrementBy = value; }
        }
        private int _IncrementBy;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.HLen(_Hash));
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
        public IEnumerable<KeyValuePair<string,string>> KeyValuePair
        {
            get { return _KeyValuePair; }
            set { _KeyValuePair = value; }
        }
        private IEnumerable<KeyValuePair<string, string>> _KeyValuePair;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SetRangeInHash(_Hash, _KeyValuePair);
        }

        protected override void EndProcessing()
        {

        }
    }

    #endregion

}
