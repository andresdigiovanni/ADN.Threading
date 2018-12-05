using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ADN.Threading
{
    /// <summary>
    /// A static class that provides a mechanism that synchronizes access to objects.
    /// </summary>
    public static class Lock
    {
        /// <summary>
        /// Attempts, for the specified number of milliseconds, to acquire an exclusive lock
        /// on the specified object, and execute the action.
        /// </summary>
        /// <param name="obj">The object on which to acquire the lock.</param>
        /// <param name="millisecondsTimeout">The number of milliseconds to wait for the lock.</param>
        /// <param name="action">Action to execute.</param>
        public static void CompletesIn(object obj, int millisecondsTimeout, Action action)
        {
            Exception exception = null;
            bool lockWasTaken = false;
            try
            {
                Monitor.TryEnter(obj, millisecondsTimeout, ref lockWasTaken);
                if (lockWasTaken)
                {
                    action();
                }
                else
                {
                    throw new TimeoutException("Timeout exceeded, unable to lock.");
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                if (lockWasTaken)
                {
                    Monitor.Exit(obj);
                }

                if (exception != null)
                {
                    throw new Exception("An exception occured during the lock proces.", exception);
                }
            }
        }
    }
}
