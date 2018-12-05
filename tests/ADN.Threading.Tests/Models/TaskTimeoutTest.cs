using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace ADN.Threading.Tests
{
    public class TaskTimeoutTest
    {
        private const int DELAY_MILLISECONDS = 100;
        private const int EXCESS_DELAY_MILLISECONDS = 400;
        private const int TIMEOUT_MILLISECONDS = 200;

        [Fact]
        public void CompletesIn()
        {
            DelayFunction(TIMEOUT_MILLISECONDS, DELAY_MILLISECONDS);
        }

        [Fact]
        public void CompletesIn_Expception_Timeout()
        {
            Assert.Throws<TimeoutException>(() =>
                DelayFunction(TIMEOUT_MILLISECONDS, EXCESS_DELAY_MILLISECONDS)
            );
        }

        private void DelayFunction(int timeout, int delay)
        {
            TaskTimeout.CompletesIn(timeout, () =>
            {
                Thread.Sleep(delay);
            });
        }
    }
}
