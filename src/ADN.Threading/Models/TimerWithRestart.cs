﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ADN.Threading
{
    /// <summary>
    /// Safe overlap timer with stop and restart.
    /// </summary>
    public class TimerWithRestart
    {
        private readonly Timer _timer;
        private readonly TimerCallback _callback;
        private readonly int _dueTime;
        private readonly int _period;
        private readonly object _lockobj = new object();

        /// <summary>
        /// Initializes a new instance of the TimerWithRestart class.
        /// </summary>
        /// <param name="callback">A System.Threading.TimerCallback delegate representing a method to be executed.</param>
        /// <param name="state">An object containing information to be used by the callback method, or null.</param>
        /// <param name="dueTime">The amount of time to delay before callback is invoked, in milliseconds.
        /// Specify System.Threading.Timeout.Infinite to prevent the timer from starting.
        /// Specify zero (0) to start the timer immediately.</param>
        /// <param name="period">The time interval between invocations of callback, in milliseconds.
        /// Specify System.Threading.Timeout.Infinite to disable periodic signaling.</param>
        public TimerWithRestart(TimerCallback callback, object state, int dueTime, int period)
        {
            _callback = callback;
            _dueTime = dueTime;
            _period = period;
            _timer = new Timer(DoWork, state, dueTime, period);
        }

        /// <summary>
        /// Releases all resources used by the current instance of ADN.Threading.TimerWithRestart.
        /// </summary>
        public void Dispose()
        {
            _timer.Dispose();
        }

        private void DoWork(object state)
        {
            var hasLock = false;
            Exception exception = null;

            try
            {
                Monitor.TryEnter(_lockobj, ref hasLock);
                if (!hasLock)
                {
                    return;
                }
                _timer.Change(Timeout.Infinite, Timeout.Infinite);

                _callback(state);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                if (hasLock)
                {
                    Monitor.Exit(_lockobj);
                    _timer.Change(_dueTime, _period);
                }

                if (exception != null)
                {
                    throw exception;
                }
            }
        }
    }
}
