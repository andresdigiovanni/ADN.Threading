using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Threading
{
    /// <summary>
    /// A static class to execute asynchronous operations.
    /// </summary>
    public static class TaskTimeout
    {
        /// <summary>
        /// Waits for the provided operation to complete execution within a specified time interval.
        /// </summary>
        /// <param name="millisecondsTimeout">The number of milliseconds to wait.</param>
        /// <param name="action">Operation on which to wait.</param>
        /// <exception cref="TimeoutException">Task not completed within the specified time interval.</exception>
        /// <example>
        /// <code lang="csharp">
        /// var timeout = 1000;
        /// TaskTimeout.CompletesIn(timeout, () =>
        /// {
        ///     // your function
        /// });
        /// </code>
        /// </example>
        public static void CompletesIn(int millisecondsTimeout, Action action)
        {
            var task = Task.Run(action);
            var completedInTime = Task.WaitAll(new[] { task }, TimeSpan.FromMilliseconds(millisecondsTimeout));

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
                throw new TimeoutException($"Task did not complete in {millisecondsTimeout} milliseconds.");
            }
        }
    }
}
