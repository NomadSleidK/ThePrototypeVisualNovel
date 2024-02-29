using TMPro;

public class StraightReader : Reader
{
    private TextMeshProUGUI _name;
    private TextMeshProUGUI _text;
    
    public StraightReader(TextMeshProUGUI name, TextMeshProUGUI text)
    {
        _name = name;
        _text = text;
    }

    public override void NextDialog()
    {

    }

    public override void NextLine()
    {
        if (_index == _dialogs.Get.Length) return;

        _name.SetText(_dialogs.Get[_index].Name);
        _text.SetText(_dialogs.Get[_index].Text);
        _index++;
    }
}
