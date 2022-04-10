using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using JetBrains.Annotations;
using ReactiveUI;

namespace ListEditor.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private bool is_selected;
    public ReactiveCommand<Unit, Unit> CreateListCommand { get; }
    public ReactiveCommand<Unit, Unit> ExitCommand { get; }

    private string _ListName;
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

        core = new ListEditorCore();

    }

    public void CreateList()
    {
        Console.WriteLine(ListName);
        core.CreateEmptyList(ListName);
        ListName = "";
    }

    public void Exit()
    {
        Environment.Exit(0);
    }

}


