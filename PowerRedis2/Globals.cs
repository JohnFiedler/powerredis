
using System.Management.Automation;
using ServiceStack.Redis;
using System.Collections.Generic;
using System;

[assembly: CLSCompliant(false)]
namespace PowerRedis2
{
    public static class Globals
    {
        public static RedisClient rc { get; set; }
        public static bool IsConnected { get; set; }
    }
}
