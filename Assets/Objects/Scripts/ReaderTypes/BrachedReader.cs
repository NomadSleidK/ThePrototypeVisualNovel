using Game.Dialogs;
using TMPro;
using UnityEngine;

public class BrachedReader : Reader
{
    private TextMeshProUGUI _name;
    private TextMeshProUGUI _text;
    private GameObject _choiceMenu;
    private BranchedDialog _branchedDialog;

    public BrachedReader(TextMeshProUGUI Name, TextMeshProUGUI Text, GameObject ChoiceMenu)
    {
        _name = Name;
        _text = Text;
        _choiceMenu = ChoiceMenu;
    }

    public override void NextDialog()
    {
        _branchedDialog = (BranchedDialog)_dialogs;
        _choiceMenu.SetActive(true);
        ChoiceMenu Menu = _choiceMenu.GetComponent<ChoiceMenu>();
        Menu.CreateNewChoices(_branchedDialog.GetNextOptions);
    }

    public override void NextLine()
    {
        if (_index == _dialogs.Get.Length)
            return;

        _name.SetText(_dialogs.Get[_index].Name);
        _text.SetText(_dialogs.Get[_index].Text);
        _index++;

        if (_index == _dialogs.Get.Length)
        {
            NextDialog();
        }
    }
}
