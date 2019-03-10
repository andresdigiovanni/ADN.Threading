using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;


namespace ADN.Threading.Tests
{
    public class LockTest
    {
        private const int NUM_THREADS = 10;
        private const int DELAY_FUNCTION_MILLISECONDS = 100;
        private const int EXCESS_DELAY_FUNCTION_MILLISECONDS = 5000;
        private const int LOCK_TIMEOUT_MILLISECONDS = 1000;
        private const int WAIT_UNTIL_THREAD_START_MILLISECONDS = 100;


        [Fact]
        public void CompletesIn_Expception_Timeout()
        {
            object lockObj = new object();
            Thread thread = new Thread(() =>
            {
                DelayFunctionWithLock(lockObj, EXCESS_DELAY_FUNCTION_MILLISECONDS, LOCK_TIMEOUT_MILLISECONDS);
            });
            thread.Start();

            Thread.Sleep(WAIT_UNTIL_THREAD_START_MILLISECONDS);
            Assert.Throws<TimeoutException>(() =>
                DelayFunctionWithLock(lockObj, DELAY_FUNCTION_MILLISECONDS, LOCK_TIMEOUT_MILLISECONDS)
            );
        }

        [Fact]
        public void CompletesIn_CheckConcurrency()
        {
            bool concurrentThreadsLessThanTwo = DelayFunctionWithMultipleThreads(DELAY_FUNCTION_MILLISECONDS, LOCK_TIMEOUT_MILLISECONDS);

            Assert.True(concurrentThreadsLessThanTwo);
        }

        private bool DelayFunctionWithMultipleThreads(int delay, int timeout)
        {
            int numThreadsInLockSection = 0;
            bool concurrentThreadsLessThanTwo = true;
            object lockObj = new object();
            List<Thread> listThread = new List<Thread>();

            for (int i = 0; i < NUM_THREADS; i++)
            {
                Thread thread = new Thread(() =>
                {
                    Lock.CompletesIn(lockObj, timeout, () =>
                    {
                        numThreadsInLockSection++;
                        concurrentThreadsLessThanTwo &= numThreadsInLockSection == 1;

                        DelayFunction(delay);

                        numThreadsInLockSection--;
                    });
                });
                thread.Start();
                listThread.Add(thread);
            }

            WaitJoinAllThreads(listThread);
            return concurrentThreadsLessThanTwo;
        }

        private void DelayFunctionWithLock(object lockObj, int delay, int timeout)
        {
            Lock.CompletesIn(lockObj, timeout, () =>
            {
                DelayFunction(delay);
            });
        }

        private void DelayFunction(int delay)
        {
            Thread.Sleep(delay);
        }

        private void WaitJoinAllThreads(List<Thread> listThread)
        {
            foreach (Thread thread in listThread)
            {
                thread.Join();
            }
        }
    }
}
