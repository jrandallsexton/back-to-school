using System;

namespace BackToSchool.CSharp.DataStructures.Trees
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; } = null!;

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
            }
            else
            {
                Root.Add(value);
            }
        }
    }
}
