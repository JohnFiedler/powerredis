using ServiceStack.Redis;

namespace PowerRedis2
{
    public static class Utility
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


