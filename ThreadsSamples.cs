using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SamplesProjects
{


    // With threads you can execute multiple
    // pieces of code that share resources
    // and data without corrupting it

    // You can't guarantee when a thread
    // executes. You also must lock resources
    // until a thread is done with them
    // or you could corrupt them

    class ThreadsSamples
    {
        // ----- Simple Thread Example -----
        /*
        static void Main(string[] args)
        {
            // Create a thread and start it
            Thread t = new Thread(Print1);
            t.Start();
 
            // This code will run randomly
            for (int i = 0; i < 1000; i++)
                Console.Write(0);
 
            Console.ReadLine();
 
        }
 
        static void Print1()
        {
            for (int i = 0; i < 1000; i++)
                Console.Write(1);
        }
        
 
        // ----- Sleep Example -----
 
        // With sleep() the thread is suspended
        // for the designated amount of time
        static void Main(string[] args)
        {
            int num = 1;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(num);
 
                // Pause for 1 second
                Thread.Sleep(1000);
 
                num++;
            }
 
            Console.WriteLine("Thread Ends");
 
            Console.ReadLine();
        }
 
        // ----- Lock Example -----
        // lock keeps other threads from entering 
        // a statement block until another thread
        // leaves
        static void Main(string[] args)
        {
            BankAcct acct = new BankAcct(10);
            Thread[] threads = new Thread[15];
 
            // CurrentThread gets you the current
            // executing thread
            Thread.CurrentThread.Name = "main";
 
            // Create 15 threads that will call for 
            // IssueWithdraw to execute
            for (int i = 0; i < 15; i++)
            {
                // You can only point at methods
                // without arguments and that return 
                // nothing
                Thread t = new Thread(new 
                    ThreadStart(acct.IssueWithdraw));
                t.Name = i.ToString();
                threads[i] = t;
            }
 
            // Have threads try to execute
            for (int i = 0; i < 15; i++)
            {
                // Check if thread has started
                Console.WriteLine("Thread {0} Alive : {1}",
                    threads[i].Name, threads[i].IsAlive);
 
                // Start thread
                threads[i].Start();
 
                // Check if thread has started
                Console.WriteLine("Thread {0} Alive : {1}",
                    threads[i].Name, threads[i].IsAlive);
            }
 
            // Get thread priority (Normal Default)
            // Also Lowest, BelowNormal, AboveNormal
            // and Highest
            // Changin priority doesn't guarantee
            // the highest precedence though
            // It is best to not mess with this
            Console.WriteLine("Current Priority : {0}",
                Thread.CurrentThread.Priority);
 
            Console.WriteLine("Thread {0} Ending",
                Thread.CurrentThread.Name);
 
            Console.ReadLine();
        }
    }
}
 
class BankAcct
{
    private Object acctLock = new Object();
    double Balance { get; set; }
    string Name { get; set; }
 
    public BankAcct(double bal)
    {
        Balance = bal;
    }
 
    public double Withdraw(double amt)
    {
        if((Balance - amt) < 0)
        {
            Console.WriteLine($"Sorry ${Balance} in Account");
            return Balance;
        }
 
        lock (acctLock)
        {
            if(Balance >= amt)
            {
                Console.WriteLine("Removed {0} and {1} left in Account",
                amt, (Balance - amt));
                Balance -= amt;
            }
            
            return Balance;
            
        }
    }
 
    // You can only point at methods
    // without arguments and that return 
    // nothing
    public void IssueWithdraw()
    { 
        Withdraw(1);
    }
}
*/

        // ----- Passing Data to Threads -----
        // You can pass arguments to a thread 
        // using a lambda expression
        public void MainFunc()
        {
            Thread t = new Thread(() => CountTo(10));
            t.Start();

            // You can use multiline lambdas
            new Thread(() =>
            {
                CountTo(5);
                CountTo(6);
            }).Start();

            Console.ReadLine();
        }

        static void CountTo(int maxNum)
        {
            for (int i = 0; i <= maxNum; i++)
            {
                Console.WriteLine(i);
            }
        }



        // ----- ForeGround And Background Example -----

        /// <summary>
        /// by default Thread is ForeGround Thread so the Thread will complete even if the main function will end!
        /// </summary>
        public void ForeGroundThread() {
            Thread foreGrounThread = new Thread(FunctionThread);
            foreGrounThread.Start();
        }

        /// <summary>
        ///if we define Thread as Background Thread - he will end when the main function ends! 
        /// </summary>
        public void BackgroundThread() {
            Thread backgroundThread = new Thread(FunctionThread);
            backgroundThread.IsBackground = true;
            backgroundThread.Start();
        }

        /// <summary>
        /// by default Thread is ForeGround Thread so the Thread will complete even if the main function will end!
        /// if we define Thread as Background Thread - he will end when the main function ends!
        /// </summary>
        public void FunctionThread()
        {
            Console.WriteLine("FunctionThread is entered...");
            //wait until user put any input.
            Console.ReadLine();
            Console.WriteLine("FunctionThread is exited...");
        }
    }
}
