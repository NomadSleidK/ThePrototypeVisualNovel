using System;
using System.Collections;
using System.Collections.Generic;
using Game.Dialogs;
using TMPro;
using UnityEngine;

public class OptionBox : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI OptionBoxText;
    [SerializeField] public Dialog NextDialog;

    private Controller _readerController;
    private ChoiceMenu _choiceMenu;

    public void SetNextDialog()
    {
        _readerController = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();
        _readerController.ReplaceToNextDialog(NextDialog);
        ClearOptions();
    }

    private void ClearOptions()
    {
        _choiceMenu = GameObject.FindGameObjectWithTag("ChoiceMenu").GetComponent<ChoiceMenu>();
        _choiceMenu.DeleteChoices();
    }
}

