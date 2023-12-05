using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = MyDelegate.Call(Add, 8, 3);
            Console.WriteLine(result);
            Console.WriteLine(MyDelegate.Call(Sub, 8, 3));
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Sub(int a, int b)
        {
            return a - b;
        }
    }
}
