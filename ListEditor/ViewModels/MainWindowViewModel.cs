using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using JetBrains.Annotations;
using ReactiveUI;

namespace ListEditor.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    
    public ReactiveCommand<Unit, Unit> CreateListCommand { get; }
    public ReactiveCommand<Unit, Unit> ExitCommand { get; }
    
    public ReactiveCommand<Operation, Unit> ExecuteOperationCommand { get; }
    
    private Operation _operation = Operation.AddToTop;

    private bool is_selected;

    public bool IsSelected
    {
        get { return is_selected; }
        set { this.RaiseAndSetIfChanged(ref is_selected, value);}
    }

    private int[] _Values;
    public int[] Values
    {
        get { return _Values; }
        set { this.RaiseAndSetIfChanged(ref _Values, value); }
    }

    private string current_list_name;

    public string CurrentListName
    {
        get { return current_list_name; }
        set { this.RaiseAndSetIfChanged(ref current_list_name, value); SelectList();}
    }

    private string _RawUserValues;

    public string RawUserValues
    {
        get { return _RawUserValues; }
        set { this.RaiseAndSetIfChanged(ref _RawUserValues, value); }
    }

    private string _ListName;

    private string[] _ExistingNames;
    

    public string[] ExistingNames
    {
        get { return _ExistingNames; }
        set { this.RaiseAndSetIfChanged(ref _ExistingNames, value); }
    }

    private ListEditorCore core;
    public string ListName
    {
        get { return _ListName;}
        set { this.RaiseAndSetIfChanged(ref _ListName, value); }
    }
    


    public MainWindowViewModel()
    {
        CreateListCommand = ReactiveCommand.Create(CreateList);
        ExitCommand = ReactiveCommand.Create(Exit);
        ExecuteOperationCommand = ReactiveCommand.Create<Operation>(ExecuteOperation);
        core = new ListEditorCore();
        ExistingNames = core.GetListOfLists();
        IsSelected = false;

    }

    public void CreateList()
    {
        Console.WriteLine(ListName);
        core.CreateEmptyList(ListName);
        ListName = "";
        ExistingNames = core.GetListOfLists();
        
        Console.WriteLine("ExistingNames:");
        foreach(string name in ExistingNames) Console.WriteLine(name);
    }

    public void SelectList()
    {
        IsSelected = true;
        core.SelectList(CurrentListName);
        Values = core.Values;
    }


    public void Exit()
    {
        Environment.Exit(0);
    }

    private void ExecuteOperation(Operation operation)
    {
        List<int> value = StringToIntArray(RawUserValues);
        //Console.WriteLine("Кол-во элементов {0}", value.Count);

        int[] user_data = new int[value.Count];
        for (int i = 0; i < value.Count; i++) user_data[i] = value[i];
        
        
        switch (_operation)
        {
            case Operation.AddToTop:
            {
                if (user_data.Length != 0)
                {
                    Console.WriteLine("Добавлено {0} в список {1}", user_data.Length, core.SelectedListName);
                    core.AddToTop(user_data);
                    Values = core.Values;
                    Console.WriteLine("Элементы списка:");
                    foreach (int a in Values) Console.Write(" {0}", a);
                    
                }
                break;
            }
        }

        RawUserValues = "";
    }

    private List<int> StringToIntArray(string text)
    {
        string[] raw_values = text.Split(' ');
        List<int> values = new List<int>();
        
        
        foreach (string value in raw_values)
        {
            try
            {
                values.Add(Convert.ToInt32(value));
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
            }
            
        }

        
        return values;

    }

}


