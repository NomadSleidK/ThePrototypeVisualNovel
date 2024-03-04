using Game.Dialogs;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public abstract class Reader
{
    protected Dialog _dialog;
    protected int _index;
    protected Controller _readerController;
    protected Image _leftCharacterPosition;
    protected Image _rightCharacterPosition;

    public void GetNewDialog(Dialog dialog)
    {
        _dialog = dialog;
        _index = 0;
    }

    public abstract void NextLine();
    public abstract void NextDialog();


    protected void SetImageBox(bool isLeftImage)
    {
        if (isLeftImage == true)
            SetCharacterImage(_leftCharacterPosition);
        else
            SetCharacterImage(_rightCharacterPosition);
    }

    public void SetNullImage()
    {
        _leftCharacterPosition.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        _rightCharacterPosition.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    private void SetCharacterImage(Image image)
    {
        if (_dialog.Get[_index].CharacterSprite != null)
        {
            image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            image.sprite = _dialog.Get[_index].CharacterSprite;
        }
    }
}
