using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Tree
    {
        public class Element
        {
            public int Data { get; set; }
            public Element pLeft { get; set; }
            public Element pRight { get; set; }
            public Element(int data, Element pLeft=null, Element pRight=null)
            {
                this.Data = data;
                this.pLeft = pLeft;
                this.pRight = pRight;
                Console.WriteLine($"EConstructor:\t{GetHashCode()}");
            }
            ~Element()
            {
                Console.WriteLine($"EDestructor:\t{GetHashCode()}");
            }
        }
        public Element Root { get; set; }
        public Tree()
        {
            Root = null;
            Console.WriteLine($"TConstructor:\t{GetHashCode()}");
        }
        ~Tree()
        {
            Console.WriteLine($"TDestructor:\t{GetHashCode()}");
        }
        public void Insert(int Data)
        {
            Insert(Data, Root);
        }
        private void Insert(int Data, Element Root)
        {
            if (this.Root == null) this.Root = new Element(Data);
            if (Root == null) return;
            if(Data<Root.Data)
            {
                if (Root.pLeft == null) Root.pLeft = new Element(Data);
                else Insert(Data, Root.pLeft);
            }
            else
            {
                if (Root.pRight == null) Root.pRight = new Element(Data);
                else Insert(Data, Root.pRight);
            }
        }
        public void Print()
        {
            Print(Root);
            Console.WriteLine();
        }
        void Print(Element Root)
        {
            if (Root == null) return;
            Print(Root.pLeft);
            Console.Write(Root.Data + "\t");
            Print(Root.pRight);
        }
        public int MinElement()
        {
            return MinElement(Root);
        }
        int MinElement(Element Root)
        {
            if (Root == null) throw new Exception("Tree is empty");
            return Root.pLeft == null? Root.Data:MinElement(Root.pLeft);
        }
        public int MaxElement()
        {
            return MaxElement(Root);
        }
        int MaxElement(Element Root)
        {
            if (Root == null) throw new Exception("Tree is empty");
            return Root.pRight == null? Root.Data:MaxElement(Root.pRight);
        }
        public int Sum()
        {
            return Sum(Root);
        }
        int Sum(Element Root)
        {
            return Root == null ? 0 : Root.Data!=null ? Root.Data + Sum(Root.pLeft) + Sum(Root.pRight) : 0;
        }
        public int Count()
        {
            return Count(Root);
        }
        int Count(Element Root)
        {
            return Root == null ? 0 : Root.Data != null ? 1 + Count(Root.pLeft) + Count(Root.pRight) : 0;
        }
        public double Avarage()
        {
            return (double)Sum() / Count();
        }
        public void erase(int Data)
        {
            erase(Data, Root);
        }
        void erase(int Data, Element Root)
        {
            if (Root == null) return;
            erase(Data, Root.pLeft);
            erase(Data, Root.pRight);
            if (Data == Root.Data)
            {
                if (Root.pLeft == Root.pRight)
                {
                    Root = null;
                }
                else
                {
                    if (Count(Root.pLeft) > Count(Root.pRight))
                    {
                        Root.Data = MaxElement(Root.pLeft);
                        erase(MaxElement(Root.pLeft), Root.pLeft);
                    }
                    else
                    {
                        Root.Data = MinElement(Root.pRight);
                        erase(MinElement(Root.pRight), Root.pRight);
                    }
                    
                }
            }
        }
        public void clear()
        {
            clear(Root);
            Root = null;
        }
        void clear(Element Root)
        {
            if (Root == null) return;
            clear(Root.pLeft);
            clear(Root.pRight);
            Root=null;
        }
        public int depth()
	    {
		    return depth(Root);
        }
        int depth(Element Root)
	    {
		    if (Root == null)return 0;
		    int l_depth = depth(Root.pLeft) + 1;
            int r_depth = depth(Root.pRight) + 1;
		    return l_depth > r_depth? l_depth : r_depth;
	    }

    }
}
