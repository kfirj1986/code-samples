using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesProjects
{
    public class IntWrapper
    {
        public List<int> wrappedInt;
    }

    public class DoubleWrapper
    {
        public double wrappedDouble;
    }

    public class ByteWrapper
    {
        public byte wrappedByte;
    }

    class MemoryView
    {
        public void MainFunc()
        {
            var wrapped1 = new IntWrapper();
            var wrapped2 = new IntWrapper();
            var wrapped3 = new IntWrapper();
            wrapped1.wrappedInt = new List<int>() { 1 } ;
            wrapped2.wrappedInt = new List<int>() { 2 } ;
            wrapped3.wrappedInt = new List<int>() { 3 };
            GC.Collect();
            wrapped2 = null;
            GC.Collect();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
