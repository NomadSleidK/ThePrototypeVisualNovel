using Game.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ChoiceOption
{
    [SerializeField] private string _textOption;
    public string TextOption => _textOption;

    [SerializeField] private Dialog _dialog;
    public Dialog NextDialog => _dialog;
}