
using System.Text;

namespace BackToSchool.CSharp.DataStructures.LinkedLists
{
    public class LinkedList
    {
        private Node head { get; set; }

        public string PrintAllNodes()
        {
            var sb = new StringBuilder();

            var current = head;
            while (current != null)
            {
                sb.Append(current.data + " ");
                current = current.next;
            }

            return sb.ToString().TrimEnd();
        }

        public void Add(int data)
        {
            var nodeToAdd = new Node(data);
            if (head == null)
            {
                head = nodeToAdd;
            }
            else
            {
                head.next = nodeToAdd;
            }
        }

        public void AddToEnd(int data)
        {
            if (head == null)
            {
                Add(data);
            }
            else
            {
                if (head.next == null)
                {
                    head.next = new Node(data);
                }
                else
                {

                }
            }
        }

        private class Node
        {
            internal int data { get; set; }
            internal Node next { get; set; }

            public Node(int d)
            {
                data = d;
                next = null;

            }
        }
    }
}