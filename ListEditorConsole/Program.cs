// See https://aka.ms/new-console-template for more information


using ListEditor;

public class ListEditorCore
{
    private List<CycleSingleLinkedListShell> existing_lists = new List<CycleSingleLinkedListShell>();

    public string[] ListOfLists
    {
        get
        {
            string[] list_of_lists = new string[existing_lists.Count];
            for (int i = 0; i < existing_lists.Count; i ++)
            {
                list_of_lists[i] = existing_lists[i].Name;
            }
            return list_of_lists;
        }
    }

    public void CreateEmptyList(string list_name)
    {
        CycleSingleLinkedList my_list = new CycleSingleLinkedList();
        CycleSingleLinkedListShell my_list_shell = new CycleSingleLinkedListShell();
        my_list_shell.Name = list_name;
        existing_lists.Append(my_list_shell);
    }

}


class CycleSingleLinkedListShell
{
    private string list_name;
    private CycleSingleLinkedList my_list;

    public string Name
    {
        get { return list_name; }
        set
        {
            list_name = value.Trim();
        }
    }

    public CycleSingleLinkedList MyList
    {
        get { return my_list; }
        set
        {
            
        }
    }
}