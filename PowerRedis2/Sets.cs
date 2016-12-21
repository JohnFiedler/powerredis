using System.Management.Automation;
using System.Collections.Generic;
using ServiceStack.Redis;

namespace PowerRedis2
{
    //smembers
    [Cmdlet(VerbsCommon.Get, "RedisSet")]
    public class GetRedisSetCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        protected override void BeginProcessing()
        {
            
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetAllItemsFromSet(key));
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //sadds
    [Cmdlet(VerbsCommon.Add, "RedisSetItems")]
    public class AddRedisSetItemsCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        public List<string> SetItems
        {
            get { return setitems; }
            set { setitems = value; }
        }
        private List<string> setitems;


        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.AddRangeToSet(key, setitems);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    //sadd
    [Cmdlet(VerbsCommon.Add, "RedisSetItem")]
    public class AddRedisSetItemCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string SetItem
        {
            get { return setitem; }
            set { setitem = value; }
        }
        private string setitem;


        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.AddItemToSet(key, setitem);
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //scard
    [Cmdlet(VerbsCommon.Get, "RedisSetCount")]
    public class GetRedisSetCountCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;


        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SCard(key);
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //sdiff
    [Cmdlet(VerbsCommon.Set, "RedisSetDiff")]
    public class SetRedisSetDiffCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string[] Keys
        {
            get { return keys; }
            set { keys = value; }
        }
        private string[] keys;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SDiff(key, keys);
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //sdiffstore
    [Cmdlet(VerbsCommon.Set, "RedisSetDiffStore")]
    public class SetRedisSetDiffStoreCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        private string destination;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        public string[] Keys
        {
            get { return keys; }
            set { keys = value; }
        }
        private string[] keys;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SDiffStore(destination, key, keys);
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //sInter
    [Cmdlet(VerbsCommon.Set, "RedisSetIntersect")]
    public class SetRedisSetInterCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string[] Keys
        {
            get { return keys; }
            set { keys = value; }
        }
        private string[] keys;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SDiff(key, keys);
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //sIntersectStore
    [Cmdlet(VerbsCommon.Set, "RedisSetIntersectStore")]
    public class SetRedisSetIntersectStoreCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string[] Keys
        {
            get { return keys; }
            set { keys = value; }
        }
        private string[] keys;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SInterStore(key, keys);
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //sismember
    [Cmdlet(VerbsCommon.Get, "RedisSetIsMember")]
    public class GetRedisSetIsMemberCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Member
        {
            get { return member; }
            set { member = value; }
        }
        private string member;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.SetContainsItem(key, member);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
            
        }


    }

    //smove
    [Cmdlet(VerbsCommon.Get, "RedisSetMove")]
    public class GetRedisSetMoveCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        private string source;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        private string destination;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        public string Member
        {
            get { return member; }
            set { member = value; }
        }
        private string member;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.MoveBetweenSets(source, destination, member);
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //spop
    [Cmdlet(VerbsCommon.Set, "RedisSetPop")]
    public class SetRedisSetPopCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SPop(key);
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //smove
    [Cmdlet(VerbsCommon.Get, "RedisSetRandom")]
    public class GetRedisSetRandomCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.SRandMember(key);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //srem
    [Cmdlet(VerbsCommon.Remove, "RedisSetMember")]
    public class RemoveRedisSetMemberCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Member
        {
            get { return member; }
            set { member = value; }
        }
        private string member;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.RemoveItemFromSet(key, member);
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //sunion
    [Cmdlet(VerbsCommon.Add, "RedisSets")]
    public class AddRedisSetsCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string[] Keys
        {
            get { return keys; }
            set { keys = value; }
        }
        private string[] keys;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Member
        {
            get { return member; }
            set { member = value; }
        }
        private string member;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SUnion(keys);
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //sunionStore
    [Cmdlet(VerbsCommon.Add, "RedisSetsStore")]
    public class AddRedisSetsStoreCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string[] Keys
        {
            get { return keys; }
            set { keys = value; }
        }
        private string[] keys;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        private string destination;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", System.Management.Automation.ErrorCategory.ConnectionError, ""));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SUnionStore(destination, keys);
        }

        protected override void EndProcessing()
        {
            
        }

    }

}
