<a name='assembly'></a>
# ADN.Threading

## Contents

- [Lock](#T-ADN-Threading-Lock 'ADN.Threading.Lock')
  - [CompletesIn(obj,millisecondsTimeout,action)](#M-ADN-Threading-Lock-CompletesIn-System-Object,System-Int32,System-Action- 'ADN.Threading.Lock.CompletesIn(System.Object,System.Int32,System.Action)')
- [TaskTimeout](#T-ADN-Threading-TaskTimeout 'ADN.Threading.TaskTimeout')
  - [CompletesIn(millisecondsTimeout,action)](#M-ADN-Threading-TaskTimeout-CompletesIn-System-Int32,System-Action- 'ADN.Threading.TaskTimeout.CompletesIn(System.Int32,System.Action)')

<a name='T-ADN-Threading-Lock'></a>
## Lock `type`

##### Namespace

ADN.Threading

##### Summary

A static class that provides a mechanism that synchronizes access to objects.

<a name='M-ADN-Threading-Lock-CompletesIn-System-Object,System-Int32,System-Action-'></a>
### CompletesIn(obj,millisecondsTimeout,action) `method`

##### Summary

Attempts, for the specified number of milliseconds, to acquire an exclusive lock
on the specified object, and execute the action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The object on which to acquire the lock. |
| millisecondsTimeout | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of milliseconds to wait for the lock. |
| action | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | Action to execute. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.TimeoutException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TimeoutException 'System.TimeoutException') | Timeout exceeded, unable to lock. |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | An exception occured during the lock proces. |

##### Example

```csharp
var lockObj = new object();
var timeout = 1000;
Lock.CompletesIn(lockObj, timeout, () =&gt;
{ 
    // your function
}); 
```

<a name='T-ADN-Threading-TaskTimeout'></a>
## TaskTimeout `type`

##### Namespace

ADN.Threading

##### Summary

A static class to execute asynchronous operations.

<a name='M-ADN-Threading-TaskTimeout-CompletesIn-System-Int32,System-Action-'></a>
### CompletesIn(millisecondsTimeout,action) `method`

##### Summary

Waits for the provided operation to complete execution within a specified time interval.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| millisecondsTimeout | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of milliseconds to wait. |
| action | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | Operation on which to wait. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.TimeoutException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TimeoutException 'System.TimeoutException') | Task not completed within the specified time interval. |

##### Example

```csharp
var timeout = 1000;
TaskTimeout.CompletesIn(timeout, () =&gt;
{
    // your function
}); 
```
