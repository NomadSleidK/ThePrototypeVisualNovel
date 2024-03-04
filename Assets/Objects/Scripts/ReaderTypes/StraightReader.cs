using Game.Dialogs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StraightReader : Reader
{
    private TextMeshProUGUI _name;
    private TextMeshProUGUI _text;
    private StraightDialog _straightDialog;
    
    public StraightReader(TextMeshProUGUI name, TextMeshProUGUI text, Controller readerController, Image leftCharacterPosition, Image rightCharacterPosition)
    {
        _name = name;
        _text = text;
        _readerController = readerController;
        _leftCharacterPosition = leftCharacterPosition;
        _rightCharacterPosition = rightCharacterPosition;
    }

    public override void NextDialog()
    {
        _straightDialog = (StraightDialog)_dialog;
        _readerController.ReplaceToNextDialog(_straightDialog.NextDialog);
    }

    public override void NextLine()
    {
        if (_index == _dialog.Get.Length)
        {
            NextDialog();
            return;
        }

        SetImageBox(_dialog.Get[_index].IsLEftImageBox);

        _name.SetText(_dialog.Get[_index].Name);
        _text.SetText(_dialog.Get[_index].Text);
        _index++;
    }
}
