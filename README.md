Project Description
=======

port from https://powerredis.codeplex.com/

This project provides a way to access a Redis server via Powershell Cmdlets. You can use command like Get-RedisKey, Add-RedisSetItems, and Remove-RedisHashEntry to manipulate the keys on the redis server.



# Requirements

Free Redis Server = http://redis.io/
Powershell
.Net 4.0
How to get started

Download the Zip file and extract it to one of the module directories for powershell
`C:\Windows\System32\WindowsPowerShell\v1.0\Modules`

To make Powershell support .Net 4.0 create or edit your PowerShell.exe.Config in `C:\Windows\System32\WindowsPowerShell\v1.0`to look like this 

    <?xml version="1.0"?> 
    <configuration> 
    <startup useLegacyV2RuntimeActivationPolicy="true"> 
    <supportedRuntime version="v4.0.30319"/> 
    <supportedRuntime version="v2.0.50727"/> 
    </startup> 
    </configuration>

Import the module using Import-Module PowerRedis
`get-module –list PowerRedis | import-module`

Make sure your redis server is up and running.
Use `Connect-RedisServer –RedisServer <dns name or IP of your server>` e.g. `Connect-RedisServer -RedisServer 192.168.1.2`

Type `Search-RedisKeys *` to get a list of your redis keys. FYI this could take a while if you have a lot of keys…

# Useful Links

[ServiceStack](https://github.com/ServiceStack/ServiceStack.Redis) C# library this project wraps  
[Redis Homepage](http://redis.io/)


# Cmdlet Mapping

## Keys	
KEYS	Search-RedisKeys  
DEL	Remove-RedisKey  
EXISTS	Get-RedisExists  
EXPIRE	Set-RedisExpire  
EXPIREAT	Set-RedisExpiresAt  
RANDOMKEY	Get-RedisRandomKey  
RENAME	Rename-RedisKey  
TTL	Get-RedisTTL  
Type	Get-RedisType  
--Not implemented	 
Move,object,persist,renamenx,sort,eval	

## Strings	
GET	Get-RedisKey  
SET	Set-RedisKey  
--Not implemented	
append,decr,decrby,getbit,getrange,getset	 
incr,mget,mset,msetnx,setbit,setex,setnx,setrange	 

## Hashes	 
HSET	Set-RedisHashValue  
HSETNX	Set-RedisHashValueIfNotExists  
HMGET	Get-RedisHashAll  
HGET	Get-RedisHashValue  
HGETVALUES	Get-RedisHashValues  
HKKEYS	Get-RedisHashKeys  
HDEL	Remove-RedisHashEntry  
HEXISTS	Get-RedisHashExists  
HINCRBY	Set-RedisHashIncrement  
HLEN	Get-RedisHashLength  
HMSET	Set-RedisHashValues  

## Lists	
Get-RedisList  
Add-RedisListItems  
RPUSH	Add-RedisListItem  
LRANGE	Get-RedisListRange  
BLPOP	Get-RedisLBPOP  
BRPOPLPUSH	Set-RedisBRPopLPush  
LINDEX	Get-RedisListIndex  
LLEN	Get-RedisListLength  
LPOP	Remove-RedisListLPop  
RPOP	Remove-RedisListRPop  
LREM	Remove-RedisListElements  
LTRIM	Set-RedisListTrim  
--Not Implemented	 
linsert, lset, lpush, rpoplpush, rpushx, lpushx



## Sets	 
SMEMBERS	Get-RedisSet  
SADDS	Add-RedisSetItems  
SADD	Add-RedisSetItem  
SCARD	Get-RedisSetCount  
SDIFF	Set-RedisSetDiff  
SDIFFSTORE	Set-RedisSetDiffStore  
SINTER	Set-RedisSetIntersect  
SINTERSECTSTORE	Set-RedisSetIntersectStore  
SISMEMBER	Get-RedisSetIsMember  
SMOVE	Get-RedisSetMove  
SPOP	Set-RedisSetPop  
SMOVE	Get-RedisSetRandom  
SREM	Remove-RedisSetMember  
SUNION	Add-RedisSets  
SUNIONSTORE	Add-RedisSetsStore  

## SortedSets	 
ZADDSCORE	Add-RedisSortedSetItemScore  
ZADD	Add-RedisSortedSetItem  
ZCARD	Get-RedisSortedSetCount  
-- Not Implemented	
zcount,zincrby,zinterstore,zrange,zrangebyscore,zrank  
zrem,zremrangebyrank,zremrangebyscore,zrevrange  
zrevrank,zscore,zunionstore	 

## Strings	
GET	Get-RedisKey  
SET	Set-RedisKey  

## Server	 
INFO	Get-RedisInfo  

## Others not implemented	 
Pub/Sub and Transactions
