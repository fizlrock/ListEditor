using System;
using System.Collections.Generic;
using Avalonia.Media;

namespace ListEditor;

public enum Operation
{
    AddToTop,
    AddToEnd,
    DeleteAtTop,
    DeleteAtEnd
}

public class ListEditorCore
{
    private List<MyList> existing_lists = new List<MyList>();
    private MyList selected_list;
    
    public void AddToTop(int value){selected_list.list.append_first(value);}
    public void AddToTop(int[] value){selected_list.list.append_first(value);}
    public void AddToEnd(int value){selected_list.list.append(value);}
    public void AddToEnd(int[] value){selected_list.list.AddToEnd(value);}

    public int[] Values
    {
        get { return selected_list.list.Array; }
    }

    public int Lenght
    {
        get { return selected_list.list.Count(); }
    }


    public void SelectList(int number)
    {
        // Выбрать список по номеру
       selected_list = existing_lists[number];
    }

    public void SelectList(string name)
    {
        MyList list = null;
        int i = 0;
        while (!Equals(existing_lists[i].name, name)) i++;
        if (Equals(existing_lists[i].name, name)) selected_list = existing_lists[i];
        else
        {
            throw new Exception();
        }

    }

    public string SelectedListName
    {
        get
        {
            string name = "";
            if (selected_list != null) name = selected_list.name;
            return name;
        }
    }

    public bool IsSelect()
    {

            if (selected_list != null)
            {
                return true;
            }
            else return false;
        
    }

    public string[] GetListOfLists()
    {
        string[] list_of_lists = new string[existing_lists.Count];
        for (int i = 0; i < existing_lists.Count; i++)
        {
            list_of_lists[i] = existing_lists[i].name;
        }
        return list_of_lists;
    }

    public void CreateEmptyList(string list_name)
    {
        existing_lists.Add(new MyList(list_name));
    }


}


public class MyList
{
    public SingleLinkedList list;
    public string name;
    
    public MyList(string list_name)
    {
        name = list_name;
        list = new SingleLinkedList();
    }
}