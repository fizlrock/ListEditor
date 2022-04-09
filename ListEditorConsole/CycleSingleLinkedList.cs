using System.Collections.Concurrent;

namespace ListEditor;

public class CycleSingleLinkedList
{

    private Node head; // ссылка на головной узел списка
    public CycleSingleLinkedList() // конструктор по умолчанию - создани элементарного односвязного кольца

    {
        head = new Node();
        head.Link = head;
    }
    
    public void AppendBegin(int[ ] dates)

        // dates – массив значений информационных полей        preview.Link = head
        // Функция создания списка с добавлением элементов в начало списка(до head)

    {
        for (int i = 0; i < dates.Length; i++)
        {
            Node p = new Node( dates[i] ); // вставка узла в начало списка
            p.Link = head.Link; // установка связи между вставленным узлом и cписком
            head.Link = p; // обновление поля связи головного узла
        }
    }

    public void AppendEnd(int[] dates)
    //Функция добавления элементов в конец списка
    {
        Node preview = head;
        for (int i = 0; i< dates.Length; i++)
        {
            Node current = new Node(dates[i], head);
            preview.Link = current;
            preview = current;
        } 
    }

    public void DropFirstNode()
    {
        if (head != null) head.Link = head.Link.Link;
        
    }

    public Node PupFirstNode()
    {
        Node deleted = null;
        if (head != null && head.Link!= head)
        {
            deleted = head.Link;
            head.Link = head.Link.Link;
        }
        return deleted;
    }

    public void Print()
    {
        Node current = head.Link;
        String output = "";
        while (current != head)
        {
            output += Convert.ToString(current.Info);
            current = current.Link;
        }
        Console.WriteLine(output);
    }

    public void DropExceptTheFirst()
    {
        if (head != null)
        {
            Node selected = head.Link;
            while (selected != head)
            {
                Node preview = selected;
                Node current = selected.Link;

                while (current != head)
                {
                    if (current.Info == selected.Info)
                    {
                        preview.Link = current.Link;
                        current = current.Link;
                    }
                    else
                    {

                        preview = current;
                        current = current.Link;
                    }
                }

                selected = selected.Link;
            }
        }
    }


}
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