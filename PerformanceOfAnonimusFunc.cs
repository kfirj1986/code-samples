using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesProjects
{
    class PerformanceOfAnonimusFunc
    {
        delegate int PointToAddFunction(int num1, int num2);
        public void MainFunc()
        {
            Console.WriteLine("Test Performance with delegate to function");
            Stopwatch stopwatch = new Stopwatch();
            for (int x = 0; x < 10; x++)
            {
                stopwatch.Reset();
                stopwatch.Start();
                for (int y = 0; y < 1000; y++)
                {
                    PointToAddFunction pointAdd = Add;
                    pointAdd.Invoke(2,2);
                }
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedTicks.ToString());
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("***************");

            Console.WriteLine("Test Performance with delegate to Anonimus function");
            for (int x = 0; x < 10; x++)
            {
                stopwatch.Reset();
                stopwatch.Start();
                for (int y = 0; y < 1000; y++)
                {
                    PointToAddFunction pointAdd = delegate(int num1, int num2) {
                        return num1 + num2;
                    };
                    pointAdd.Invoke(2, 2);
                }
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedTicks.ToString());
            }

        }

        static int Add(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
