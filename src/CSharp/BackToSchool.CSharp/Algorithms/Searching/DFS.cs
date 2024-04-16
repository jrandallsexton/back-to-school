using BackToSchool.CSharp.DataStructures.Trees;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Algorithms.Searching
{
    public class DFS
    {
        public StringBuilder Logs = new();

        public void GenerateTraversal<T>(Node<T> node) where T : IComparable<T>
        {
            if (node == null)
                return;

            Logs.AppendLine(node.Value + " ");
            //Console.WriteLine(node.Value + " ");

            GenerateTraversal<T>(node.Left);
            GenerateTraversal<T>(node.Right);
        }
    }
}
