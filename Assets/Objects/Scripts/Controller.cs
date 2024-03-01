using System;
using System.Collections.Generic;
using Game.Dialogs;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject _choiceMenu;

    [SerializeField] private Dialog _activeDialog; //активный диалог
    [SerializeField] private Dialog _nextDialog; //следующий диалог
    public Dialog ActiveDialog
    {
        get
        {
            return _activeDialog;
        }
        set
        {
            _activeDialog = value;
            SetReader();
        }
    }

    [SerializeField] private TextMeshProUGUI _name; //поле имени говорящего
    private TextMeshProUGUI Name => _name;
    [SerializeField] private TextMeshProUGUI _text; //поле текста говорящего
    private TextMeshProUGUI Text => _text;

    private StraightReader _straightReader; //оператор линейного диалога
    private BranchedReader _branchedReader; //оператор разветвлённого диалога
    private Reader _activeReader; //активный оператор

    Dictionary<Type, Reader> Readers; //словарь операторова

    public void Awake()
    {
        _straightReader = new StraightReader(Name, Text, this);
        _branchedReader = new BranchedReader(Name, Text, _choiceMenu, this);

        Readers = new Dictionary<Type, Reader> //создаём словарь операторов
        {
            {typeof(StraightDialog), _straightReader},
            {typeof(BranchedDialog), _branchedReader}
        };

        ActiveDialog = _activeDialog; //устанавливаем активный диалог
        _activeReader.NextLine(); //запускаем новую линию в диалоге
    }

    private void SetReader()
    {
        _activeReader = Readers[ActiveDialog.GetType()];
        _activeReader.GetNewDialog(ActiveDialog);
    }

    public void ReplaceToNextDialog(Dialog newDialog) //заменить диалог
    {
        ActiveDialog = newDialog;
        ReadLine();
    }

    public void ReadLine()
    {
        _activeReader.NextLine();
    }
}
