using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinarySearchTree<K, V> where K : IComparable
    {
        Node<K, V> Root { get; set; }
        public virtual void Add(K key, V value)
        {
            var node = new Node<K, V>(key, value);
            if (Root == null)
            {
                Root = node;
                return;
            }
            Node<K, V> parent = null;
            var currNode = Root;
            while (currNode != null)
            {
                parent = currNode;
                if(currNode.Key.CompareTo(key) < 0)
                {
                    currNode = currNode.Right;
                    if (currNode == null) parent.Right = node;
                }
                else
                {
                    currNode = currNode.Left;
                    if (currNode == null) parent.Left = node;
                }
            }
            node.Parent = parent;
            
        }
        public IEnumerable<V> InOrderTraversal()
        {
            List<V> returnList = new List<V>();
            Traverse(Root, n =>
            {
                returnList.Add(n.Value);
            });
            return returnList;
        }
        public void Traverse(Node<K, V> n, Action<Node<K, V>> action)
        {
            if (n == null) return;
            Traverse(n.Left, action);
            action(n);
            Traverse(n.Right, action);
        }
        public V Max
        {
            get
            {
                if (Root == null) return default(V);
                var node = Root;
                while (node.Right != null)
                {
                    node = node.Right;
                }
                return node.Value;
            }
        }
        public V Min
        {
            get
            {
                if (Root == null) return default(V);
                var node = Root;
                while (node.Left != null)
                {
                    node = node.Left;
                }
                return node.Value;
            }
        }
        public void Delete(K key)
        {
            var node = FindNode(key);
            RecursiveDelete(node);
        }
        private void RecursiveDelete(Node<K,V> node)
        {
            if(node.Left == null && node.Right == null)
            {
                if (node.Parent.Right == node) node.Parent.Right = null;
                else node.Left = null;
            }
            if(node.Left != null && node.Right == null)
            {
                CopyNode(node, node.Left);
            }
            if (node.Right != null && node.Left == null)
            {
                CopyNode(node, node.Right);
            }
            else
            {
                CopyNode(node, node.Right);
                RecursiveDelete(node.Right);
            }
        }
        private void CopyNode(Node<K,V> source, Node<K,V> dest)
        {
            source.Left = dest.Left;
            source.Right = dest.Right;
            source.Key = dest.Key;
            source.Value = dest.Value;
        }
        public V this[K key]
        {
            get
            {
                return FindNode(key).Value;
            }
        }
        private Node<K,V> FindNode(K key)
        {
            var node = Root;
            int comparison = 0;
            do
            {
                comparison = node.Key.CompareTo(key);
                if (comparison < 0) node = node.Right;
                if (comparison > 0) node = node.Left;
            }
            while (comparison != 0);
            return node;
        }
    }


}
