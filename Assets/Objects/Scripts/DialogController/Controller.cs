using System;
using System.Collections.Generic;
using Game.Dialogs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject _choiceMenu;
    [SerializeField] private GameObject _backGroundParent;

    [SerializeField] protected Image _leftCharacterPosition;
    [SerializeField] protected Image _rightCharacterPosition;

    [SerializeField] private Dialog _activeDialog; //активный диалог
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

    Dictionary<Type, Reader> Readers; //словарь операторов

    public void Awake()
    {
        _straightReader = new StraightReader(Name, Text, this, _leftCharacterPosition, _rightCharacterPosition);
        _branchedReader = new BranchedReader(Name, Text, _choiceMenu, this, _leftCharacterPosition, _rightCharacterPosition);

        Readers = new Dictionary<Type, Reader> //создаём словарь операторов
        {
            {typeof(StraightDialog), _straightReader},
            {typeof(BranchedDialog), _branchedReader}
        };

        ActiveDialog = _activeDialog; //устанавливаем активный диалог
        _activeReader.NextLine(); //запускаем новую линию в диалоге
        _activeReader.SetNullImage();
    }
    
    private void SetBackGround(GameObject backGround)
    {
        GameObject newOption = Instantiate(backGround, _backGroundParent.transform);
        newOption.transform.localScale = backGround.transform.localScale;
    }

    private void SetReader()
    {
        _activeReader = Readers[ActiveDialog.GetType()];
        _activeReader.GetNewDialog(ActiveDialog);
        SetBackGround(ActiveDialog.BackGround);
    }

    public void ReplaceToNextDialog(Dialog newDialog) //заменить диалог
    {
        if (newDialog == null)
            return;
        _activeReader.SetNullImage();
        ActiveDialog = newDialog;
        ReadLine();
    }

    public void ReadLine()
    {
        _activeReader.NextLine();
    }
}
