using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinarySearchTree<K,V> where K :struct, IComparable
    {
       Node<K,V> Root { get; set; }
        public void Add(K key, V value)
        {
            var node = new Node<K,V>(key, value);
            if (Root == null)
            {
                Root = node;
                return;
            }
            var parent = Root;
            var found = false;
            while(!found)
            {
                var result = parent.Key.CompareTo(key);
                if(result < 0)
                {
                    if(parent.Right == null)
                    {
                        parent.Right = node;
                        node.Parent = parent;
                        found = true;
                    }
                    else
                    {
                        parent = parent.Right;
                    }
                }
                if (result > 0)
                {
                    if (parent.Left == null)
                    {
                        parent.Left = node;
                        node.Parent = parent;
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
        public IEnumerable<V> InOrderTraversal()
        {
            List<V> returnList = new List<V>();
            Traverse(Root, n => {
                returnList.Add(n.Value);
            });
            return returnList;
        }
        public void Traverse(Node<K,V> n, Action<Node<K,V>> action)
        {
            if (n == null) return;
            Traverse(n.Left, action);
            action(n);
            Traverse(n.Right, action);
        }
        
    }
    
    
}
