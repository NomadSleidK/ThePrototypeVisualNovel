using Game.Dialogs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BranchedReader : Reader
{
    private TextMeshProUGUI _name;
    private TextMeshProUGUI _text;
    private GameObject _choiceMenu;
    private BranchedDialog _branchedDialog;

    public BranchedReader(TextMeshProUGUI Name, TextMeshProUGUI Text, GameObject ChoiceMenu, Controller readerController, Image leftCharacterPosition, Image rightCharacterPosition)
    {
        _name = Name;
        _text = Text;
        _choiceMenu = ChoiceMenu;
        _readerController = readerController;
        _leftCharacterPosition = leftCharacterPosition;
        _rightCharacterPosition = rightCharacterPosition;
    }

    public override void NextDialog()
    {
        _branchedDialog = (BranchedDialog)_dialog;
        _choiceMenu.SetActive(true);
        ChoiceMenu Menu = _choiceMenu.GetComponent<ChoiceMenu>();
        Menu.CreateNewChoices(_branchedDialog.GetNextOptions);
    }

    public override void NextLine()
    {
        if (_index == _dialog.Get.Length)
            return;

        SetImageBox(_dialog.Get[_index].IsLEftImageBox);

        _name.SetText(_dialog.Get[_index].Name);
        _text.SetText(_dialog.Get[_index].Text);
        _index++;

        if (_index == _dialog.Get.Length)
        {
            NextDialog();
        }
    }
}
