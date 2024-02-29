using TMPro;

public class StraightReader : Reader
{
    private TextMeshProUGUI _name;
    private TextMeshProUGUI _text;
    
    public StraightReader(TextMeshProUGUI name, TextMeshProUGUI text, Controller readerController)
    {
        _name = name;
        _text = text;
        _readerController = readerController;
    }

    public override void NextDialog()
    {
        _readerController.ReplaceToNextDialog();
    }

    public override void NextLine()
    {
        if (_index == _dialog.Get.Length)
        {
            NextDialog();
            return;
        }

        _name.SetText(_dialog.Get[_index].Name);
        _text.SetText(_dialog.Get[_index].Text);
        _index++;
    }
}
