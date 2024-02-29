using Game.Dialogs;
using System;

[Serializable]
public abstract class Reader
{
    protected Dialogs _dialogs;
    protected int _index;

    public void GetNewDialog(Dialogs dialogs)
    {
        _dialogs = dialogs;
        _index = 0;
    }

    public abstract void NextLine();
    public abstract void NextDialog();
}
