using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;
using System.Management.Automation;

namespace PowerRedis2
{
    public class Utility
    {
        public static void Connect(string aRedisServer, int database)
        {
            if (aRedisServer == null)
                aRedisServer = "localhost";
            Globals.rc = new RedisClient(aRedisServer);
        }

        public static void CloseConnection()
        {
            Globals.rc.Dispose();
        }
    }

}


