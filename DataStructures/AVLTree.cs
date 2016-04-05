using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class AVLTree<K,V> : BinarySearchTree<K,V> where K : IComparable
    {
        public override void Add(K key, V value)
        {
            base.Add(key, value);
        }
    }
}
