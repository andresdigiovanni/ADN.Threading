# ADN.Threading

# Content

- [Lock](#T:ADN.Threading.Lock)

  - [CompletesIn(obj, millisecondsTimeout, action)](#Lock.CompletesIn(obj,millisecondsTimeout,action))

- [TaskTimeout](#T:ADN.Threading.TaskTimeout)

  - [CompletesIn(millisecondsTimeout, action)](#TaskTimeout.CompletesIn(millisecondsTimeout,action))

- [TimerWithLock](#T:ADN.Threading.TimerWithLock)

  - [Constructor(callback, state, dueTime, period)](#TimerWithLock.#ctor(callback,state,dueTime,period))

  - [Dispose](#TimerWithLock.Dispose)

- [TimerWithRestart](#T:ADN.Threading.TimerWithRestart)

  - [Constructor(callback, state, dueTime, period)](#TimerWithRestart.#ctor(callback,state,dueTime,period))

  - [Dispose](#TimerWithRestart.Dispose)

- [TimerWithTryEnter](#T:ADN.Threading.TimerWithTryEnter)

  - [Constructor(callback, state, dueTime, period)](#TimerWithTryEnter.#ctor(callback,state,dueTime,period))

  - [Dispose](#TimerWithTryEnter.Dispose)

<a name='T:ADN.Threading.Lock'></a>


## Lock

A static class that provides a mechanism that synchronizes access to objects.

<a name='Lock.CompletesIn(obj,millisecondsTimeout,action)'></a>


### CompletesIn(obj, millisecondsTimeout, action)

Attempts, for the specified number of milliseconds, to acquire an exclusive lock on the specified object, and execute the action.


#### Parameters

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>The object on which to acquire the lock. |

#### Parameters

| millisecondsTimeout | *System.Int32*<br>The number of milliseconds to wait for the lock. |

#### Parameters

| action | *System.Action*<br>Action to execute. |

*System.TimeoutException:* Timeout exceeded, unable to lock.

*System.Exception:* An exception occured during the lock proces.


#### Example

```csharp
var lockObj = new object();
var timeout = 1000;
Lock.CompletesIn(lockObj, timeout, () =>
{
// your function
});
```

<a name='T:ADN.Threading.TaskTimeout'></a>


## TaskTimeout

A static class to execute asynchronous operations.

<a name='TaskTimeout.CompletesIn(millisecondsTimeout,action)'></a>


### CompletesIn(millisecondsTimeout, action)

Waits for the provided operation to complete execution within a specified time interval.


#### Parameters

| Name | Description |
| ---- | ----------- |
| millisecondsTimeout | *System.Int32*<br>The number of milliseconds to wait. |

#### Parameters

| action | *System.Action*<br>Operation on which to wait. |

*System.TimeoutException:* Task not completed within the specified time interval.


#### Example

```csharp
var timeout = 1000;
TaskTimeout.CompletesIn(timeout, () =>
{
// your function
});
```

<a name='T:ADN.Threading.TimerWithLock'></a>


## TimerWithLock

Safe overlap timer with lock.

<a name='TimerWithLock.#ctor(callback,state,dueTime,period)'></a>


### Constructor(callback, state, dueTime, period)

Initializes a new instance of the TimerWithLock class.


#### Parameters

| Name | Description |
| ---- | ----------- |
| callback | *System.Threading.TimerCallback*<br>A System.Threading.TimerCallback delegate representing a method to be executed. |

#### Parameters

| state | *System.Object*<br>An object containing information to be used by the callback method, or null. |

#### Parameters

| dueTime | *System.Int32*<br>The amount of time to delay before callback is invoked, in milliseconds. Specify System.Threading.Timeout.Infinite to prevent the timer from starting. Specify zero (0) to start the timer immediately. |

#### Parameters

| period | *System.Int32*<br>The time interval between invocations of callback, in milliseconds. Specify System.Threading.Timeout.Infinite to disable periodic signaling. |
<a name='TimerWithLock.Dispose'></a>


### Dispose

Releases all resources used by the current instance of ADN.Threading.TimerWithLock.

<a name='T:ADN.Threading.TimerWithRestart'></a>


## TimerWithRestart

Safe overlap timer with stop and restart.

<a name='TimerWithRestart.#ctor(callback,state,dueTime,period)'></a>


### Constructor(callback, state, dueTime, period)

Initializes a new instance of the TimerWithRestart class.


#### Parameters

| Name | Description |
| ---- | ----------- |
| callback | *System.Threading.TimerCallback*<br>A System.Threading.TimerCallback delegate representing a method to be executed. |

#### Parameters

| state | *System.Object*<br>An object containing information to be used by the callback method, or null. |

#### Parameters

| dueTime | *System.Int32*<br>The amount of time to delay before callback is invoked, in milliseconds. Specify System.Threading.Timeout.Infinite to prevent the timer from starting. Specify zero (0) to start the timer immediately. |

#### Parameters

| period | *System.Int32*<br>The time interval between invocations of callback, in milliseconds. Specify System.Threading.Timeout.Infinite to disable periodic signaling. |
<a name='TimerWithRestart.Dispose'></a>


### Dispose

Releases all resources used by the current instance of ADN.Threading.TimerWithRestart.

<a name='T:ADN.Threading.TimerWithTryEnter'></a>


## TimerWithTryEnter

Safe overlap timer with try enter.

<a name='TimerWithTryEnter.#ctor(callback,state,dueTime,period)'></a>


### Constructor(callback, state, dueTime, period)

Initializes a new instance of the TimerWithTryEnter class.


#### Parameters

| Name | Description |
| ---- | ----------- |
| callback | *System.Threading.TimerCallback*<br>A System.Threading.TimerCallback delegate representing a method to be executed. |

#### Parameters

| state | *System.Object*<br>An object containing information to be used by the callback method, or null. |

#### Parameters

| dueTime | *System.Int32*<br>The amount of time to delay before callback is invoked, in milliseconds. Specify System.Threading.Timeout.Infinite to prevent the timer from starting. Specify zero (0) to start the timer immediately. |

#### Parameters

| period | *System.Int32*<br>The time interval between invocations of callback, in milliseconds. Specify System.Threading.Timeout.Infinite to disable periodic signaling. |
<a name='TimerWithTryEnter.Dispose'></a>


### Dispose

Releases all resources used by the current instance of ADN.Threading.TimerWithTryEnter.

