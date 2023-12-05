using System;
using System.Collections.Generic;
using System.Configuration;
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
                //Console.WriteLine($"EConstructor:\t{GetHashCode()}");
            }
            ~Element()
            {
                //Console.WriteLine($"EDestructor:\t{GetHashCode()}");
            }
        }
        protected Element Root { get; set; }
        public Tree()
        {
            Root = null;
            Console.WriteLine($"TConstructor:\t{GetHashCode()}");
        }
        public Tree(params int[] values):this()
        {
            foreach (int i in values)
            {
                Insert(i, Root);
            }
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
        public int MinElement()=> MinElement(Root);
        
        int MinElement(Element Root)
        {
            if (Root == null) throw new Exception("Tree is empty");
            return Root.pLeft == null? Root.Data:MinElement(Root.pLeft);
        }
        public int MaxElement()=>MaxElement(Root);

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
        public void Erase(int Data)=>Erase(Data, Root, null);

        void Erase(int Data, Element Root, Element Parent)
        {
            if (Root == null) return;
            Erase(Data, Root.pLeft, Root);
            Erase(Data, Root.pRight, Root);
            if (Data == Root.Data)
            {
                if (Root.pLeft == Root.pRight)
                {
                    if (Root.Equals(Parent.pLeft)) Parent.pLeft = null;
                    if (Root.Equals(Parent.pRight)) Parent.pRight = null;
                    Root = null;
                    GC.Collect(1);
                }
                else
                {
                    if (Count(Root.pLeft) > Count(Root.pRight))
                    {
                        Root.Data = MaxElement(Root.pLeft);
                        Erase(MaxElement(Root.pLeft), Root.pLeft, Root);
                    }
                    else
                    {
                        Root.Data = MinElement(Root.pRight);
                        Erase(MinElement(Root.pRight), Root.pRight, Root);
                    }
                }
            }
        }
        public void Clear()
        {
            Root = null;
            GC.Collect(1);
        }
        public int Depth()=>Depth(Root);
        
        int Depth(Element Root)
	    {
		    if (Root == null)return 0;
		    int l_depth = Depth(Root.pLeft) + 1;
            int r_depth = Depth(Root.pRight) + 1;
		    return l_depth > r_depth? l_depth : r_depth;
	    }

    }
}
