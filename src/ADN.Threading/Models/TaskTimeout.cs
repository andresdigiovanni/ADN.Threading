using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Threading
{
    /// <summary>
    /// A static class to execute asynchronous operations.
    /// </summary>
    /// Waits for all of the provided cancellable System.Threading.Tasks.Task objects
        //     to complete execution within a specified time interval.
    public static class TaskTimeout
    {
        /// <summary>
        /// Waits for the provided operation to complete execution within a specified time interval.
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait.</param>
        /// <param name="action">Operation on which to wait.</param>
        public static void CompletesIn(int timeout, Action action)
        {
            var task = Task.Run(action);
            var completedInTime = Task.WaitAll(new[] { task }, TimeSpan.FromMilliseconds(timeout));

            if (task.Exception != null)
            {
                if (task.Exception.InnerExceptions.Count == 1)
                {
                    throw task.Exception.InnerExceptions[0];
                }

                throw task.Exception;
            }

            if (!completedInTime)
            {
                throw new TimeoutException($"Task did not complete in {timeout} milliseconds.");
            }
        }
    }
}
