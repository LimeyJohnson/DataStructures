using System;

namespace DataStructures
{
    public class Node<T> where T :struct
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Value { get; set; }
        public Node (T value)
        {
            this.Value = value;
        }
    }
}
