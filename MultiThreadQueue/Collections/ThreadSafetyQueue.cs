using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MultiThreadQueue.Collections
{
    public class ThreadSafetyQueue<T>
    {
        private readonly Queue<T> _internalQueue = new Queue<T>();

        public void Push(T item)
        {
            lock (_internalQueue)
            {
                _internalQueue.Enqueue(item);
                Monitor.PulseAll(_internalQueue);
            }

        }

        public T Pop()
        {
            lock (_internalQueue)
            {
                while (!_internalQueue.Any())
                {
                    Monitor.Wait(_internalQueue);
                }
                return _internalQueue.Dequeue();
            }
        }

        public override string ToString()
        {
            lock (_internalQueue)
            {
                return String.Join(",", _internalQueue);
            }
        }
    }
}
