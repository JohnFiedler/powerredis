using ServiceStack.Redis;
using System.Management.Automation;


namespace PowerRedis2
{

    //zaddscore
    [Cmdlet(VerbsCommon.Add, "RedisSortedSetItemScore")]
    public class AddRedisSortedSetItemScoreCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double Score { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
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
            WriteObject(Globals.rc.AddItemToSortedSet(this.Key,this.Member,this.Score));
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
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
            WriteObject(Globals.rc.AddItemToSortedSet(this.Key, this.Member));
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
            WriteObject(Globals.rc.ZCard(this.Key));
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
           WriteObject(Globals.rc.GetSortedSetCount(this.Key));
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Field { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double Value { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.IncrementItemInSortedSet(this.Key,this.Field,this.Value));
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int FromRank { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int ToRank { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetRangeFromSortedSet(this.Key, this.FromRank, this.ToRank));
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int FromRank { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int ToRank { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetRangeWithScoresFromSortedSet(this.Key, this.FromRank, this.ToRank));
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
            WriteObject(Globals.rc.GetItemIndexInSortedSet(this.Key, this.Value));
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
        public string IntoSetId { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string[] SetIds { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.StoreIntersectFromSortedSets(this.IntoSetId, this.SetIds));
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
            WriteObject(Globals.rc.RemoveItemFromSortedSet(this.Key, this.Value));
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int MinRank { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int MaxRank { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.RemoveRangeFromSortedSet(this.Key, this.MinRank, this.MaxRank));
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double FromScore { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double ToScore { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.RemoveRangeFromSortedSetByScore(this.Key, this.FromScore, this.ToScore));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zrevrange
    [Cmdlet(VerbsCommon.Get, "RedisSortedSetRangeDescendingIndex")]
    public class GetRedisSortedSetRangeDescendingIndexCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double FromScore { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double ToScore { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetRangeFromSortedSetByHighestScore(this.Key, this.FromScore, this.ToScore));
        }

        protected override void EndProcessing()
        {

        }
    }

    //zrevrangebyscore
    [Cmdlet(VerbsCommon.Get, "RedisSortedSetRangeDescScore")]
    public class GetRedisSortedSetRangeDescendingScoreCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double FromScore { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public double ToScore { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.GetRangeWithScoresFromSortedSetByHighestScore(this.Key, this.FromScore, this.ToScore));
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
            WriteObject(Globals.rc.GetItemScoreInSortedSet(this.Key, this.Value));
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
        public string Key { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string[] Sets { get; set; }

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(Globals.rc.StoreUnionFromSortedSets(this.Key, this.Sets));
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
