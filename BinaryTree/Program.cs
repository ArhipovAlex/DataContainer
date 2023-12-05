#define BASE_CHECK
//#define ERASE_CHECK
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Program
    {
        public delegate void NoParameters();
        static void Main(string[] args)
        {
#if BASE_CHECK
            Random random = new Random(0);
            Console.WriteLine("Введите размер дерева: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(n);
            Tree tree = new Tree();
            for (int i = 0; i < n; i++)
            {
                tree.Insert(random.Next(100));
            }
            tree.Print();
            //tree.Clear();
            Stopwatch sw = new Stopwatch();
            try
            {

                sw.Start();
                Console.WriteLine($"Минимальное значение в дереве: {tree.MinElement()}");
                sw.Stop();
                Console.WriteLine($"Вычислено за: {sw.Elapsed}");
                NoParameters noPrm = new(tree.MinElement);
                //TreePreformance.Measure("Максимальное значение в дереве: ",tree.MaxElement(), tree);
                Console.WriteLine($"Максимальное значение в дереве:{tree.MaxElement()}");
                Console.WriteLine($"Сумма элементов дерева: {tree.Sum()}");
                Console.WriteLine($"Количество элементов дерева: {tree.Count()}");
                Console.WriteLine($"Среднее арифметическое дерева: {tree.Avarage()}");
                Console.WriteLine($"Глубина дерева: {tree.Depth()}");
                Console.Write("Введите удаляемое значение: ");
                int value = Convert.ToInt32(Console.ReadLine());
                tree.Erase(value);
                tree.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"Количество элементов дерева: {tree.Count()}");
            /*
            UniqueTree u_tree = new UniqueTree();
            for(int i=0;i<n;i++)
            {
                u_tree.Insert(random.Next(100));
            }
            u_tree.Print();
            Console.WriteLine($"Минимальное значение в дереве: {u_tree.MinElement()}");
            Console.WriteLine($"Максимальное значение в дереве:{u_tree.MaxElement()}");
            Console.WriteLine($"Сумма элементов дерева: {u_tree.Sum()}");
            Console.WriteLine($"Количество элементов дерева: {u_tree.Count()}");
            Console.WriteLine($"Среднее арифметическое дерева: {u_tree.Avarage()}");
            */
#endif //BASE_CHECK
#if ERASE_CHECK
            Tree tree = new Tree(50,25,75,16,32,64,80);
            tree.Print();
            Console.WriteLine($"Глубина дерева: {tree.Depth()}");
            Console.Write("Введите удаляемое значение: ");
            int value=Convert.ToInt32(Console.ReadLine());
            tree.Erase(value);
            tree.Print();
#endif //ERASE_CHECK
        }

        
    }
}
