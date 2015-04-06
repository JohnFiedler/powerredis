using System.Management.Automation;
using ServiceStack.Redis;
using System.Collections.Generic;
using System;


namespace PowerRedis2
{

    //zaddscore
    [Cmdlet(VerbsCommon.Add, "RedisSortedSetItemScore")]
    public class AddRedisSortedSetItemScoreCommand : Cmdlet
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
        public double Score
        {
            get { return score; }
            set { score = value; }
        }
        private double score;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Member
        {
            get { return member; }
            set { member = value; }
        }
        private string member;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.AddItemToSortedSet(key,member,score));
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //zadd
    [Cmdlet(VerbsCommon.Add, "RedisSortedSetItem")]
    public class AddRedisSortedSetItemCommand : Cmdlet
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
        public string Member
        {
            get { return member; }
            set { member = value; }
        }
        private string member;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.AddItemToSortedSet(key, member));
        }

        protected override void EndProcessing()
        {
            
        }

    }

    //zcard
    [Cmdlet(VerbsCommon.Get, "RedisSortedSetCard")]
    public class GetRedisSortedSetCardCommand : Cmdlet
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
            WriteObject(Globals.rc.ZCard(key));
        }

        protected override void EndProcessing()
        {
            
        }
    }


    //zcount
    [Cmdlet(VerbsCommon.Get, "RedisSortedSetCount")]
    public class GetRedisSortedSetCountCommand : Cmdlet
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
           WriteObject(Globals.rc.GetSortedSetCount(key));
        }

        protected override void EndProcessing()
        {

        }
    }


    //zincrby
    [Cmdlet(VerbsCommon.Set, "RedisSortedSetIncrementBy")]
    public class GetRedisSortedSetIncrementByCommand : Cmdlet
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
        public string Field
        {
            get { return field; }
            set { field = value; }
        }
        private string field;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private double _Value;

        

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.IncrementItemInSortedSet(key,field,_Value));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zrange
    [Cmdlet(VerbsCommon.Get, "RedisSortedSetRange")]
    public class GetRedisSortedSetRangeCommand : Cmdlet
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
        public int FromRank
        {
            get { return fromrank; }
            set { fromrank = value; }
        }
        private int fromrank;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int ToRank
        {
            get { return torank; }
            set { torank = value; }
        }
        private int torank;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetRangeFromSortedSet(key, fromrank, torank));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zrangebyscore
    [Cmdlet(VerbsCommon.Get, "RedisSortedSetRangeByScore")]
    public class GetRedisSortedSetRangeByScoreCommand : Cmdlet
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
        public int FromRank
        {
            get { return fromrank; }
            set { fromrank = value; }
        }
        private int fromrank;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int ToRank
        {
            get { return torank; }
            set { torank = value; }
        }
        private int torank;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetRangeWithScoresFromSortedSet(key, fromrank, torank));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zrank
    [Cmdlet(VerbsCommon.Get, "RedisSortedSetRank")]
    public class GetRedisSortedSetRankCommand : Cmdlet
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
            WriteObject(Globals.rc.GetItemIndexInSortedSet(key, _value));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zinterstore
    [Cmdlet(VerbsCommon.Set, "RedisSortedSetInterstore")]
    public class GetRedisSortedSetInterstoreCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string IntoSetID
        {
            get { return intosetid; }
            set { intosetid = value; }
        }
        private string intosetid;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string[] SetIDs
        {
            get { return setids; }
            set { setids = value; }
        }
        private string[] setids;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.StoreIntersectFromSortedSets(intosetid, setids));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zrem
    [Cmdlet(VerbsCommon.Remove, "RedisSortedSetItem")]
    public class RemoveRedisSortedSetItemCommand : Cmdlet
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
            WriteObject(Globals.rc.RemoveItemFromSortedSet(key, _value));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zremrangebyrank
    [Cmdlet(VerbsCommon.Remove, "RedisSortedSetRange")]
    public class RemoveRedisSortedSetRangeCommand : Cmdlet
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
        public int MinRank
        {
            get { return minrank; }
            set { minrank = value; }
        }
        private int minrank;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int MaxRank
        {
            get { return maxrank; }
            set { maxrank = value; }
        }
        private int maxrank;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.RemoveRangeFromSortedSet(key, minrank, maxrank));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zremrangebyrank
    [Cmdlet(VerbsCommon.Remove, "RedisSortedSetRangeByScore")]
    public class RemoveRedisSortedSetRangeByScoreCommand : Cmdlet
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
        public double FromScore
        {
            get { return fromscore; }
            set { fromscore = value; }
        }
        private double fromscore;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double ToScore
        {
            get { return toscore; }
            set { toscore = value; }
        }
        private double toscore;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.RemoveRangeFromSortedSetByScore(key, fromscore, toscore));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zrevrange
    [Cmdlet(VerbsCommon.Get, "RedisSortedSetRangeDescIndex")]
    public class GetRedisSortedSetRangeDescIndexCommand : Cmdlet
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
        public double FromScore
        {
            get { return fromscore; }
            set { fromscore = value; }
        }
        private double fromscore;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double ToScore
        {
            get { return toscore; }
            set { toscore = value; }
        }
        private double toscore;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetRangeFromSortedSetByHighestScore(key, fromscore, toscore));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zrevrangebyscore
    [Cmdlet(VerbsCommon.Get, "RedisSortedSetRangeDescScore")]
    public class GetRedisSortedSetRangeDescScoreCommand : Cmdlet
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
        public double FromScore
        {
            get { return fromscore; }
            set { fromscore = value; }
        }
        private double fromscore;

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double ToScore
        {
            get { return toscore; }
            set { toscore = value; }
        }
        private double toscore;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetRangeWithScoresFromSortedSetByHighestScore(key, fromscore, toscore));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zscore
    [Cmdlet(VerbsCommon.Get, "RedisSortedSetScore")]
    public class GetRedisSortedSetScoreCommand : Cmdlet
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
            WriteObject(Globals.rc.GetItemScoreInSortedSet(key, _value));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zunionstore
    [Cmdlet(VerbsCommon.Set, "RedisSortedSetUnionStore")]
    public class SetRedisSortedSetUnionStoreCommand : Cmdlet
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
        public string[] Sets
        {
            get { return _value; }
            set { _value = value; }
        }
        private string[] _value;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected) { WriteObject("Not Connected"); }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.StoreUnionFromSortedSets(key, _value));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zcount
    //zincrby
    //zrange
    //zrangebyscore
    //zrank
    //zinterstore
    //zrem
    //zremrangebyrank
    //zremrangebyscore
    //zrevrange
    //zrevrangebyscore
    //zscore
    //zunionstore

    //zrevrank
    

}
