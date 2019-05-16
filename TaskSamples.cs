using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SamplesProjects
{
    class TaskSamples
    {
        public void MainFunc()
        {
            //מה שיקרה פה זה שכל מיליון הריצות יקראו בצורה סינכרונית וע"י ליבת מעבד אחת
            //גם אם המחשב מכיל 8 ליבות ולכן זה יכול אפילו לפגוע בביצועים
            Thread thread = new Thread(RunMillionIterations);
            thread.Start();


            //אם נפעיל טאסקים בצורה הזו אז בעצם המחשב יחלק את המשימה שלו בין כל ליבות המעבד שברשותו
            Parallel.For(0, 1000000, x => RunMillionIterations());
            Console.ReadLine();
        }

        public void RunMillionIterations() {
            string x = "";
            for (int i = 0; i < 1000000; i++)
            {
                x = x + "s";
            }
        }
    }
}
