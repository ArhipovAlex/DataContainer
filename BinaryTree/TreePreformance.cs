using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BinaryTree
{
    class TreePreformance<T>
    {
        public delegate T Method();
        public static void Measure(string message, Method method)
        {
            Stopwatch sw= new Stopwatch();
            sw.Start();
            T value = method();
            sw.Stop();
            Console.WriteLine($"{message.PadRight(40)} {value.ToString().PadRight(12)}, вычислено за: {sw.Elapsed.ToString("ss\\.ffffff")} секунд.");
        }

    }
}
