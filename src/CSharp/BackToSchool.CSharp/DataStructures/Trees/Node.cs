using System;

namespace BackToSchool.CSharp.DataStructures.Trees;

public class Node<T> where T : IComparable<T>
{
    public T Value { get; private set; }
    public Node<T> Left { get; private set; } = null!;
    public Node<T> Right { get; private set; } = null!;

    public Node(T value) => Value = value;

    public void Add(T newValue)
    {
        if (newValue.CompareTo(Value) < 0)
        {
            if (Left == null)
            {
                Left = new Node<T>(newValue);
            }
            else
            {
                Left.Add(newValue);
            }
        }
        else
        {
            if (Right == null)
            {
                Right = new Node<T>(newValue);
            }
            else
            {
                Right.Add(newValue);
            }
        }
    }
}