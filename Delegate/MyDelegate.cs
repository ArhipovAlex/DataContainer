using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class MyDelegate
    {
        public delegate int Function(int a, int b);
        public static int Call(Function function, int a, int b)
        {
            return function(a, b);
        }
    }
}
