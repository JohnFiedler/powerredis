
using System.Management.Automation;
using ServiceStack.Redis;
using System.Collections.Generic;
using System;

namespace PowerRedis2
{
    public class Globals
    {
        public static RedisClient rc { get; set; }
        public static bool IsConnected { get; set; }
    }
}
