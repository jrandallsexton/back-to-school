using BackToSchool.CSharp.DataStructures.Trees;

using System;
using System.Collections.Generic;

namespace BackToSchool.CSharp.Algorithms.Searching
{
    public class Bfs
    {
        public void GenerateTraversal<T>(Node<T> node) where T : IComparable<T>
        {
            var queue = new Queue<Node<T>>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                Console.WriteLine(node.Value + " ");

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }
    }
}
