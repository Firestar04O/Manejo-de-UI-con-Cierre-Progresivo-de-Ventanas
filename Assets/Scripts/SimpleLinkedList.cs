using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node<T>
{
    public T value;
    public Node<T> next;
    public Node(T _value)
    {
        value = _value;
        next = null;
    }
}
public class SimpleLinkedList<T>
{
    public Node<T> head = null;
    public Node<T> lastNode = null;
    public void Add(Node<T> newNode)
    {
        if (head == null)
        {
            head = newNode;
            lastNode = newNode;
            return;
        }
        lastNode.next = newNode;
        lastNode = newNode;
    } 
    public Node<T> RemoveLast()
    {
        Node<T> nodeToRemove;
        if (head == null)
        {
            return null;
        }
        if(head == lastNode)
        {
            nodeToRemove = head;
            head = null;
            lastNode = null;
            return nodeToRemove;
        }
        Node<T> currentNode = head;
        while(currentNode.next != lastNode)
        {
            currentNode = currentNode.next;
        }
        nodeToRemove = lastNode;
        currentNode.next = null;
        lastNode = currentNode;
        return nodeToRemove;
    }
    public int CountActiveWindows()
    {
        int count = 0;
        Node<T> currentNode = head;
        while(currentNode != null)
        {
            count++;
            currentNode = currentNode.next;
        }
        return count;
    }
}
