using System;

namespace DataStructures
{
    public class Node<K,V> where K :struct
    {
        public Node<K,V> Left { get; set; }
        public Node<K,V> Right { get; set; }
        public V Value { get; set; }
        public K Key { get; set; }
        public Node (K key, V value)
        {
            this.Value = value;
            this.Key = key;
        }
        public Node<K,V> Parent { get; set; }
    }
}
