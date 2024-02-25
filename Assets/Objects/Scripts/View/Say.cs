using Game.Data;
using UnityEngine;
using TMPro;

namespace Data.View
{
    public class Say: MonoBehaviour
    {
        [SerializeField] private Dialogs _dialogs; //поле для диалога
        [SerializeField] private Dialogs _newDialogs; //поле для диалога
        [SerializeField] private TextMeshProUGUI _name; //поле вывода имени
        [SerializeField] private TextMeshProUGUI _text; //поле вывода текста

        private int _index;

        private void Start ()
        {
            if(_dialogs != null) NextLine();
        }

        public void NextLine ()
        {
            if (_index == _dialogs.Get.Length) return;

            _name.SetText(_dialogs.Get[_index].Name);
            _text.SetText(_dialogs.Get[_index].Text);
            _index++;
        }

        public void NextDialog()
        {
            _dialogs = _newDialogs;
            _index = 0;
            NextLine();
        }
    }
}

