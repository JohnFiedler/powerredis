using System.Management.Automation;
using System.Collections.Generic;
using System;
using System.Collections;
using ServiceStack.Redis;

namespace PowerRedis2
{
    //KEYS
    [Cmdlet(VerbsCommon.Search, "RedisKeys")]
    public class SearchRedisKeysCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Pattern
        {
            get { return _Pattern; }
            set { _Pattern = value; }
        }
        private string _Pattern;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            if (_Pattern == null)
                _Pattern = "*";
            
            List<string> info = Globals.rc.SearchKeys(_Pattern);
            WriteObjects(info);
        }

        protected override void EndProcessing()
        {
            
        }

        protected void WriteObjects(IEnumerable objects)
        {
            foreach (var obj in objects)
            {
                WriteObject(obj);
            }
        }
    }

    //del
    [Cmdlet(VerbsCommon.Remove, "RedisKey")]
    public class RemoveRedisKeyCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
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
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.Del(keys);
        }

        protected override void EndProcessing()
        {

        }
    }

    //exists
    [Cmdlet(VerbsCommon.Get, "RedisExists")]
    public class GetRedisExistsCommand : Cmdlet
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
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.Exists(key);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {

        }
    }

    //expire
    [Cmdlet(VerbsCommon.Set, "RedisExpire")]
    public class SetRedisExpireCommand : Cmdlet
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
        public int Seconds
        {
            get { return _Seconds; }
            set { _Seconds = value; }
        }
        private int _Seconds;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.Expire(key, _Seconds);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {

        }

    }

    //expireat
    [Cmdlet(VerbsCommon.Set, "RedisExpiresAt")]
    public class SetRedisExpiresAtCommand : Cmdlet
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
        public DateTime ExpireAt
        {
            get { return expireat; }
            set { expireat = value; }
        }
        private DateTime expireat;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.ExpireEntryAt(key, expireat);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    //randomkey
    [Cmdlet(VerbsCommon.Get, "RedisRandomKey")]
    public class GetRedisRandomKeyCommand : Cmdlet
    {
        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.RandomKey();
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    //rename
    [Cmdlet(VerbsCommon.Rename, "RedisKey")]
    public class RenameRedisKeyCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string From
        {
            get { return _From; }
            set { _From = value; }
        }
        private string _From;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string To
        {
            get { return _To; }
            set { _To = value; }
        }
        private string _To;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            Globals.rc.Rename(_From,_To);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    //ttl
    [Cmdlet(VerbsCommon.Get, "RedisTTL")]
    public class GetRedisTTLCommand : Cmdlet
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
            var info = Globals.rc.Ttl(_Key);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    //Type
    [Cmdlet(VerbsCommon.Get, "RedisType")]
    public class GetRedisTypeCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position=0, ValueFromPipeline=true)]
        [ValidateNotNullOrEmpty]
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private string _Key;

        protected override void BeginProcessing()
        {
            if (!Globals.IsConnected)
            {
                WriteError(new ErrorRecord(new RedisException("Not Connected"), "Not Connected", ErrorCategory.NotSpecified, null));
            }
        }

        protected override void ProcessRecord()
        {
            var info = Globals.rc.Type(_Key);
            WriteObject(info);
        }

        protected override void EndProcessing()
        {
            
        }
    }

    ////not implemented
    //move
    //object
    //persist
    //renamenx
    //sort    
    //eval

}
