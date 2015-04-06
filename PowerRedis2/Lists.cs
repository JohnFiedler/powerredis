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
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string name;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetAllItemsFromList(name));
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
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string name;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public List<string> ListItems
        {
            get { return listitems; }
            set { listitems = value; }
        }
        private List<string> listitems;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); } 
        }

        protected override void ProcessRecord()
        {
            Globals.rc.AddRangeToList(name, listitems);
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
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string name;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string ListItem
        {
            get { return listitem; }
            set { listitem = value; }
        }
        private string listitem;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); } 
        }

        protected override void ProcessRecord()
        {
            Globals.rc.AddItemToList(name, listitem);
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
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string name;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int StartIndex
        {
            get { return startindex; }
            set { startindex = value; }
        }
        private int startindex;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int EndIndex
        {
            get { return endindex; }
            set { endindex = value; }
        }
        private int endindex;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetRangeFromList(name, startindex, endindex));
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
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public TimeSpan Timeout
        {
            get { return _Timeout; }
            set { _Timeout = value; }
        }
        private TimeSpan _Timeout;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.BlockingRemoveStartFromList(_Key,_Timeout);
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
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public TimeSpan Timeout
        {
            get { return _Timeout; }
            set { _Timeout = value; }
        }
        private TimeSpan _Timeout;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.BlockingPopItemFromList(_Key, _Timeout);
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
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        private string _Source;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }
        private string _Destination;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.PopAndPushItemBetweenLists(_Source, _Destination);
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
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }
        private int _Index;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.LIndex(_Key, _Index);
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
            var info = Globals.rc.LLen(_Key);
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
            Globals.rc.LPop(_Key);
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
            Globals.rc.RPop(_Key);
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
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private string _Value;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        private int _Count;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.RemoveItemFromList(_Key, _Value, _Count);
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
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int Start
        {
            get { return _Start; }
            set { _Start = value; }
        }
        private int _Start;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int Stop
        {
            get { return _Stop; }
            set { _Stop = value; }
        }
        private int _Stop;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.LTrim(_Key, _Start, _Stop);
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
