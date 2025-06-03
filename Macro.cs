using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TFlex.DOCs.Model.Macros;
using TFlex.DOCs.Model.Macros.ObjectModel;
using TFlex.DOCs.Model.References;

public class Macro : MacroProvider
{
    private static readonly Dictionary<string, string> _documentMetods = new Dictionary<string, string>
    {
        { "имя док", "метод" }
    };

    public Macro(MacroContext context) : base(context) { }

    public override void Run()
    {

    }

    public void CreateNewDocument()
    {
        var dialog = Context.CreateInputDialog();
        dialog.Caption = "Выбор документа";
        dialog.AddMultiselectFromList("Документ", [_documentMetods.Keys], true);

        if (!dialog.Show(Context))
            return;

        string document = dialog.GetValue("Документ");
        if (String.IsNullOrEmpty(document))
            return;

        if (!_documentMetods.TryGetValue(document, out string method))
            throw new MacroException($"Метод для создания документа '{document}' не найден.");

        
    }

    private void Create()
    {
        var dialog = Context.CreateInputDialog();
        dialog.Caption = "Выбор документа";
    }
}