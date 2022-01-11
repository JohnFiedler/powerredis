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
        public string Key { get; set; }

        protected override void BeginProcessing()
        {
            
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetAllItemsFromSet(this.Key));
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        public List<string> SetItems { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.AddRangeToSet(this.Key, this.SetItems);
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string SetItem { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.AddItemToSet(this.Key, this.SetItem);
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
            Globals.rc.SCard(this.Key);
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
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
            Globals.rc.SDiff(this.Key, this.Keys);
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Destination { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
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
            Globals.rc.SDiffStore(this.Destination, this.Key, this.Keys);
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
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
            Globals.rc.SDiff(this.Key, this.Keys);
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
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
            Globals.rc.SInterStore(this.Key, this.Keys);
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Member { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.SetContainsItem(this.Key, this.Member);
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
        public string Source { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Destination { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        public string Member { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.MoveBetweenSets(this.Source, this.Destination, this.Member);
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
            Globals.rc.SPop(this.Key);
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
            var info = Globals.rc.SRandMember(this.Key);
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Member { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.RemoveItemFromSet(this.Key, this.Member);
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
        public string[] Keys { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Member { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SUnion(this.Keys);
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
        public string[] Keys { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Destination { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.SUnionStore(this.Destination, this.Keys);
        }

        protected override void EndProcessing()
        {
            
        }

    }

}
