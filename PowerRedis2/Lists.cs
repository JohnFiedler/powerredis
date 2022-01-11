using System.Management.Automation;
using ServiceStack.Redis;
using System.Collections.Generic;
using System;


namespace PowerRedis2
{
    //
    [Cmdlet(VerbsCommon.Get, "RedisList")]
    public class GetRedisListCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetAllItemsFromList(this.Name));
        }

        protected override void EndProcessing()
        {
        
        }
    }

    //
    [Cmdlet(VerbsCommon.Add, "RedisListItems")]
    public class AddRedisListItemsCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public List<string> ListItems { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.AddRangeToList(this.Name, this.ListItems);
            //WriteObject(Globals.rc.AddRangeToList(name, listitems));
        }

        protected override void EndProcessing()
        {
           
        }
    }

    //rpush
    [Cmdlet(VerbsCommon.Add, "RedisListItem")]
    public class AddRedisListItemCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string ListItem { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.AddItemToList(this.Name, this.ListItem);
        }

        protected override void EndProcessing()
        {
           
        }
    }

    //lrange
    [Cmdlet(VerbsCommon.Get, "RedisListRange")]
    public class GetRedisListRangeCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int StartIndex { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int EndIndex { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetRangeFromList(this.Name, this.StartIndex, this.EndIndex));
        }

        protected override void EndProcessing()
        {
           
        }
    }

    //BLPOP
    [Cmdlet(VerbsCommon.Get, "RedisBLPOP")]
    public class GetRedisBLPOPCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public TimeSpan Timeout { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.BlockingRemoveStartFromList(this.Key,this.Timeout);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
           
        }
    }

    //BRPOP
    [Cmdlet(VerbsCommon.Get, "RedisBRPOP")]
    public class GetRedisBRPOPCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public TimeSpan Timeout { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.BlockingPopItemFromList(this.Key, this.Timeout);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
           
        }
    }

    //brpoplpush
    [Cmdlet(VerbsCommon.Set, "RedisBRPopLPush")]
    public class SetRedisBRPopLPushCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Source { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
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
            var info = Globals.rc.PopAndPushItemBetweenLists(this.Source, this.Destination);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
           
        }
    }

    //lindex
    [Cmdlet(VerbsCommon.Get, "RedisListIndex")]
    public class GetRedisListIndexCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int Index { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.LIndex(this.Key, this.Index);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
           
        }
    }

    //llen
    [Cmdlet(VerbsCommon.Get, "RedisListLength")]
    public class GetRedisListLengthCommand : Cmdlet
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
            var info = Globals.rc.LLen(this.Key);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
           
        }
    }

    //lpop
    [Cmdlet(VerbsCommon.Remove, "RedisListLPop")]
    public class RemoveRedisListLPopCommand : Cmdlet
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
            Globals.rc.LPop(this.Key);
        }

        protected override void EndProcessing()
        {
           
        }
    }

    //rpop
    [Cmdlet(VerbsCommon.Remove, "RedisListRPop")]
    public class RemoveRedisListRPopCommand : Cmdlet
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
            Globals.rc.RPop(this.Key);
        }

        protected override void EndProcessing()
        {
           
        }
    }

    //lrem
    [Cmdlet(VerbsCommon.Remove, "RedisListElements")]
    public class RemoveRedisListElementsCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int Count { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.RemoveItemFromList(this.Key, this.Value, this.Count);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
           
        }
    }

    //ltrim
    [Cmdlet(VerbsCommon.Set, "RedisListTrim")]
    public class SetRedisListTrimCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int Start { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int Stop { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.LTrim(this.Key, this.Start, this.Stop);
        }

        protected override void EndProcessing()
        {
           
        }
    }

    ////not implemented
    //linsert
    //lset
    //lpush
    //rpoplpush
    //rpushx
    //lpushx

}
