using System;
using System.Collections.Generic;
using Game.Dialogs;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject _choiceMenu;

    [SerializeField] private Dialogs _dialogs; //активный диалог
    [SerializeField] private Dialogs _nextDialogs; //следующий диалог
    public Dialogs Dialogs
    {
        get
        {
            return _dialogs;
        }
        set
        {
            _dialogs = value;
            SetReader();
        }
    }

    [SerializeField] private TextMeshProUGUI _name; //поле имени говорящего
    private TextMeshProUGUI Name => _name;
    [SerializeField] private TextMeshProUGUI _text; //поле текста говорящего
    private TextMeshProUGUI Text => _text;

    private StraightReader _straightReader; //оператор линейного диалога
    private BrachedReader _brachedReader; //оператор разветвлённого диалога
    private Reader _activeReader; //активный оператор

    Dictionary<Type, Reader> Readers; //словарь операторова

    public void Awake()
    {
        _straightReader = new StraightReader(Name, Text);
        _brachedReader = new BrachedReader(Name, Text, _choiceMenu);

        Readers = new Dictionary<Type, Reader> //создаём словарь операторов
        {
            {typeof(StraightDialog), _straightReader},
            {typeof(BranchedDialog), _brachedReader}
        };

        Dialogs = _dialogs; //устанавливаем активный диалог
        _activeReader.NextLine(); //запускаем новую линию в диалоге
    }

    private void SetReader() //устанока активного оператора для чтения диалога
    {
        _activeReader = Readers[Dialogs.GetType()];
        _activeReader.GetNewDialog(Dialogs);
    }

    public void ReplaceDialog() //заменить диалог
    {
        Dialogs = _nextDialogs;
        ReadLine();
    }

    public void ReadLine() //сделуюзая линия диалога
    {
        _activeReader.NextLine();
    }
}
