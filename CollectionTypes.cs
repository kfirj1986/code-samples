using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesProjects
{
    class CollectionTypes
    {
        public void MainFunc()
        {

            #region Index Based
            //Index Based
            var index = 3;
            int[] arr = new int[5];
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();

            // get to data by index
            var res = arr[index];
            res = list[index];

            linkedList.AddFirst(1);
            linkedList.AddAfter(linkedList.First, 4);
            linkedList.AddLast(9);
            res = linkedList.ElementAt(index);
            #endregion

            #region Key value pair Based
            //Key value pair Based
            Hashtable hashtable = new Hashtable();
            hashtable[1] = "One";
            hashtable[2] = "Two";
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }

            SortedList sortedList = new SortedList();
            sortedList.Add(1, "A");
            sortedList.Add(2, "B");
            foreach (DictionaryEntry entry in sortedList)
            {
                Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }
            #endregion

            #region Prioritized collections
            Stack<int> stack = new Stack<int>();
            stack.Push(3);
            stack.Push(5);
            stack.Push(7);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());



            Queue queue = new Queue();
            queue.Enqueue(2);
            queue.Enqueue(4);
            queue.Enqueue(6);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());


            ConcurrentQueue<Object> concurrentQueue = new ConcurrentQueue<object>();
            concurrentQueue.Enqueue(11);
            concurrentQueue.Enqueue(14);
            concurrentQueue.Enqueue(20);

            object x;
            bool isSuccess = concurrentQueue.TryDequeue(out x);

            //BlockingQueue blockingQueue = new BlockingQueue<object>();

            #endregion

        }
    }
}
