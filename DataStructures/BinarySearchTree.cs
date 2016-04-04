using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinarySearchTree<T> where T :struct, IComparable
    {
       Node<T> Root { get; set; }
        public void Add(T value)
        {
            var node = new Node<T>(value);
            if (Root == null)
            {
                Root = node;
                return;
            }
            var parent = Root;
            var found = false;
            while(!found)
            {
                var result = parent.Value.CompareTo(value);
                if(result > 0)
                {
                    if(parent.Right == null)
                    {
                        parent.Right = node;
                        found = true;
                    }
                    else
                    {
                        parent = parent.Right;
                    }
                }
                if (result < 0)
                {
                    if (parent.Left == null)
                    {
                        parent.Left = node;
                        found = true;
                    }
                    else
                    {
                        parent = parent.Left;
                    }
                }
                if (result == 0) throw new ArgumentOutOfRangeException("value", "Duplicate Record Detected");
            }
        }
    }
    
    
}
