using System;

namespace ListEditor;



public class Node
{
    private int info;
    private Node link;

    public int Info
    {
        get { return info; }
        set { info = value; }
    }

    public Node Link
    {
        get { return link; }
        set { link = value; }
    }

    public Node() { }

    public Node(int info)
    {
        Info = info;
    }

    public Node(int info, Node link)
    {
        Info = info;
        Link = link;
    }
}

public class SingleLinkedList
{
    private Node first;

    public SingleLinkedList() { first = null; }

    public void append_first(int a)
    {
        Node new_first = new Node(a, first);
        first = new_first;
    }

    public void append_first(int[] data)
    {

        for (int i = 0; i < data.Length; i++)
        {
            Node new_first = new Node(data[i], first);
            first = new_first;
        }
    }

    public void append(int a)
    {
        Node current = first;
        if (current == null)
        {
            first = new Node(a, null);
        }
        else
        {
            while (current.Link != null)
            {
                current = current.Link;
            }
            current.Link = new Node(a, null);
        }
    }

    public void AddToEnd(int[] numbers)
    {
        if (numbers.Length != 0 && first != null)
        {
            Node last = first;
            while (last.Link != null) last = last.Link;
            for (int i = 0; i < numbers.Length; i++)
            {
                Node new_last = new Node(numbers[i], null);
                last.Link = new_last;
                last = new_last;
            }
        }
    }

    public void append(int[] a)
    {
        Node p, last;

        if (a.Length == 0) first = null;

        else
        {
            first = new Node(a[0], null);
            last = first;
            for (int i = 1; i < a.Length; i++)
            {
                p = new Node(a[i], null);
                last.Link = p;
                last = p;

            }
        }
    }

    public void remove_head()
    {
        first = first.Link;
    }

    public void print()
    {
        Node current = first;
        while (current != null)
        {
            Console.WriteLine(current.Info);
            current = current.Link;
        }
    }

    public int[] Array
    {
        get
        {
            int[] values = new int[this.Count()];
            int i = 0;
            
            Node current = first;
            while (current != null)
            {
                values[i] = current.Info;
                i++;
                current = current.Link;
            }
            return values;
        }
    }

    public Node pup_head()
    {
        Node output = first;
        if (first != null)
        {
            first = first.Link;
        }
        return output;
    }

    public int Count()
    {
        int count = 0;
        Node current = first;
        while (current != null)
        {
            count += 1;
            current = current.Link;
        }
        return count;
    }

    public bool IsIncreases()
    {
        bool answer = true;

        if (first != null)
        {
            Node current = first;
            while (answer && (current.Link != null))
            {
                if (current.Info > current.Link.Info) answer = false;
                else { current = current.Link; }

            }
        }
        return answer;
    }


    public Node find(int a)
    {
        Node output = null;

        if (first != null) {
            output = first;

            while (output.Info != a && output.Link != null) {
                output = output.Link;
            }



        }

        
        return output;
    }

}
