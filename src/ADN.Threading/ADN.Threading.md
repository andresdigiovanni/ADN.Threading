<a name='assembly'></a>
# ADN.Threading

## Contents

- [Lock](#T-ADN-Threading-Lock 'ADN.Threading.Lock')
  - [CompletesIn(obj,millisecondsTimeout,action)](#M-ADN-Threading-Lock-CompletesIn-System-Object,System-Int32,System-Action- 'ADN.Threading.Lock.CompletesIn(System.Object,System.Int32,System.Action)')
- [TaskTimeout](#T-ADN-Threading-TaskTimeout 'ADN.Threading.TaskTimeout')
  - [CompletesIn(millisecondsTimeout,action)](#M-ADN-Threading-TaskTimeout-CompletesIn-System-Int32,System-Action- 'ADN.Threading.TaskTimeout.CompletesIn(System.Int32,System.Action)')
- [TimerWithLock](#T-ADN-Threading-TimerWithLock 'ADN.Threading.TimerWithLock')
  - [#ctor(callback,state,dueTime,period)](#M-ADN-Threading-TimerWithLock-#ctor-System-Threading-TimerCallback,System-Object,System-Int32,System-Int32- 'ADN.Threading.TimerWithLock.#ctor(System.Threading.TimerCallback,System.Object,System.Int32,System.Int32)')
  - [Dispose()](#M-ADN-Threading-TimerWithLock-Dispose 'ADN.Threading.TimerWithLock.Dispose')
- [TimerWithRestart](#T-ADN-Threading-TimerWithRestart 'ADN.Threading.TimerWithRestart')
  - [#ctor(callback,state,dueTime,period)](#M-ADN-Threading-TimerWithRestart-#ctor-System-Threading-TimerCallback,System-Object,System-Int32,System-Int32- 'ADN.Threading.TimerWithRestart.#ctor(System.Threading.TimerCallback,System.Object,System.Int32,System.Int32)')
  - [Dispose()](#M-ADN-Threading-TimerWithRestart-Dispose 'ADN.Threading.TimerWithRestart.Dispose')
- [TimerWithTryEnter](#T-ADN-Threading-TimerWithTryEnter 'ADN.Threading.TimerWithTryEnter')
  - [#ctor(callback,state,dueTime,period)](#M-ADN-Threading-TimerWithTryEnter-#ctor-System-Threading-TimerCallback,System-Object,System-Int32,System-Int32- 'ADN.Threading.TimerWithTryEnter.#ctor(System.Threading.TimerCallback,System.Object,System.Int32,System.Int32)')
  - [Dispose()](#M-ADN-Threading-TimerWithTryEnter-Dispose 'ADN.Threading.TimerWithTryEnter.Dispose')

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

<a name='T-ADN-Threading-TimerWithLock'></a>
## TimerWithLock `type`

##### Namespace

ADN.Threading

##### Summary

Safe overlap timer with lock.

<a name='M-ADN-Threading-TimerWithLock-#ctor-System-Threading-TimerCallback,System-Object,System-Int32,System-Int32-'></a>
### #ctor(callback,state,dueTime,period) `constructor`

##### Summary

Initializes a new instance of the TimerWithLock class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callback | [System.Threading.TimerCallback](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.TimerCallback 'System.Threading.TimerCallback') | A System.Threading.TimerCallback delegate representing a method to be executed. |
| state | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | An object containing information to be used by the callback method, or null. |
| dueTime | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The amount of time to delay before callback is invoked, in milliseconds.
Specify System.Threading.Timeout.Infinite to prevent the timer from starting.
Specify zero (0) to start the timer immediately. |
| period | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The time interval between invocations of callback, in milliseconds.
Specify System.Threading.Timeout.Infinite to disable periodic signaling. |

<a name='M-ADN-Threading-TimerWithLock-Dispose'></a>
### Dispose() `method`

##### Summary

Releases all resources used by the current instance of ADN.Threading.TimerWithLock.

##### Parameters

This method has no parameters.

<a name='T-ADN-Threading-TimerWithRestart'></a>
## TimerWithRestart `type`

##### Namespace

ADN.Threading

##### Summary

Safe overlap timer with stop and restart.

<a name='M-ADN-Threading-TimerWithRestart-#ctor-System-Threading-TimerCallback,System-Object,System-Int32,System-Int32-'></a>
### #ctor(callback,state,dueTime,period) `constructor`

##### Summary

Initializes a new instance of the TimerWithRestart class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callback | [System.Threading.TimerCallback](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.TimerCallback 'System.Threading.TimerCallback') | A System.Threading.TimerCallback delegate representing a method to be executed. |
| state | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | An object containing information to be used by the callback method, or null. |
| dueTime | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The amount of time to delay before callback is invoked, in milliseconds.
Specify System.Threading.Timeout.Infinite to prevent the timer from starting.
Specify zero (0) to start the timer immediately. |
| period | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The time interval between invocations of callback, in milliseconds.
Specify System.Threading.Timeout.Infinite to disable periodic signaling. |

<a name='M-ADN-Threading-TimerWithRestart-Dispose'></a>
### Dispose() `method`

##### Summary

Releases all resources used by the current instance of ADN.Threading.TimerWithRestart.

##### Parameters

This method has no parameters.

<a name='T-ADN-Threading-TimerWithTryEnter'></a>
## TimerWithTryEnter `type`

##### Namespace

ADN.Threading

##### Summary

Safe overlap timer with try enter.

<a name='M-ADN-Threading-TimerWithTryEnter-#ctor-System-Threading-TimerCallback,System-Object,System-Int32,System-Int32-'></a>
### #ctor(callback,state,dueTime,period) `constructor`

##### Summary

Initializes a new instance of the TimerWithTryEnter class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callback | [System.Threading.TimerCallback](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.TimerCallback 'System.Threading.TimerCallback') | A System.Threading.TimerCallback delegate representing a method to be executed. |
| state | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | An object containing information to be used by the callback method, or null. |
| dueTime | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The amount of time to delay before callback is invoked, in milliseconds.
Specify System.Threading.Timeout.Infinite to prevent the timer from starting.
Specify zero (0) to start the timer immediately. |
| period | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The time interval between invocations of callback, in milliseconds.
Specify System.Threading.Timeout.Infinite to disable periodic signaling. |

<a name='M-ADN-Threading-TimerWithTryEnter-Dispose'></a>
### Dispose() `method`

##### Summary

Releases all resources used by the current instance of ADN.Threading.TimerWithTryEnter.

##### Parameters

This method has no parameters.
