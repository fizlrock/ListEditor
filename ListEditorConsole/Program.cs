
using ListEditor;


ListEditorCore core = new ListEditorCore();
core.CreateEmptyList("Список №1");
core.CreateEmptyList("Список №2. Простые числа");

string[] names = core.GetListOfLists();

Console.WriteLine("Существующие списки:");
foreach (string name in names)
{
    Console.WriteLine("     "+name);
}

core.SelectList(1);

core.AddToEnd(1);
core.AddToEnd(2);
core.AddToTop(new int[]{2,1});
core.AddToEnd(new int[]{2,1});
//core.AddToEnd(new int[]{3,4,5,6});
//core.AddToTop(new int[] {1,4,5,6});
int[] values = core.Values;
foreach(int a in values) Console.Write(a);