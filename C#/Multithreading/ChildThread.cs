using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Task_4
{
    class ChildThread
    {
        public delegate void MessagesHandler();
        Thread my_thread;
        Queue<string> generalQueue;
        object locker;
        ManualResetEvent start_stop = new ManualResetEvent(true);

        public ChildThread(string name, Queue<string> q)
        {
            locker = new object();
            generalQueue = q;
            my_thread = new Thread(new ThreadStart(GenerateException));
            my_thread.Name = name;
            my_thread.IsBackground = true;
            my_thread.Start();      
        }

        public event MessagesHandler MessageOfException;        

        private void OnMessageOfException()
        {
            MessagesHandler handler = MessageOfException;
            if (handler != null)
                handler();
        }

        private void GenerateException()
        {
            while (true)
            {
                Random r = new Random();
                int k = r.Next(6);
                try
                {
                    if (k == 0)
                        throw new ArgumentOutOfRangeException();
                    if (k == 1)
                        throw new IndexOutOfRangeException();
                    if (k == 2)
                        throw new FormatException();
                    if (k == 3)
                        throw new ArgumentException();
                    if (k == 4)
                        throw new FileNotFoundException();
                    if (k == 5)
                        throw new OutOfMemoryException();
                    if (k == 6)
                        throw new InvalidCastException();
                }
                catch (Exception ex)
                {
                    lock (locker)
                    {
                        generalQueue.Enqueue(String.Format("In thread \"{0}\" was thrown next"
                                             + " exception: {1}", Thread.CurrentThread.Name,
                                             ex.GetType()));
                        OnMessageOfException();
                    }
                    Thread.Sleep(2000);
                    start_stop.WaitOne();
                }
            }
        }

        public void StopGeneration()
        {
            start_stop.Reset();
        }

        public void StartGeneration()
        {
            start_stop.Set();
        }
    }
}
