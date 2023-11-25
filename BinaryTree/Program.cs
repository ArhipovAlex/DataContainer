using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random= new Random(0);
            Console.WriteLine("Введите размер дерева: ");
            int n=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(n);
            Tree tree = new Tree();
            for(int i=0; i<n; i++) 
            {
                tree.Insert(random.Next(100));
            }
            tree.Print();
            Console.WriteLine($"Минимальное значение в дереве: {tree.MinElement()}");
            Console.WriteLine($"Максимальное значение в дереве:{tree.MaxElement()}");
            Console.WriteLine($"Сумма элементов дерева: {tree.Sum()}");
            Console.WriteLine($"Количество элементов дерева: {tree.Count()}");
            Console.WriteLine($"Среднее арифметическое дерева: {tree.Avarage()}");
        }
    }
}
