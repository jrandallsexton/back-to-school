using BackToSchool.CSharp.DataStructures.Trees;

using System;
using System.Collections.Generic;
using System.Text;

namespace BackToSchool.CSharp.Algorithms.Searching
{
    public class Bfs
    {
        public string GenerateTraversal<T>(Node<T> node) where T : IComparable<T>
        {
            var sb = new StringBuilder();

            var queue = new Queue<Node<T>>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                //Console.WriteLine(node.Value + " ");
                sb.AppendLine(node.Value + " ");

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            return sb.ToString();
        }
    }
}
