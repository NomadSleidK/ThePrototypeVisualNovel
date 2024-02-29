using Game.Dialogs;
using System;

[Serializable]
public abstract class Reader
{
    protected Dialog _dialog;
    protected int _index;
    protected Controller _readerController;


    public void GetNewDialog(Dialog dialog)
    {
        _dialog = dialog;
        _index = 0;
    }

    public abstract void NextLine();
    public abstract void NextDialog();
}
