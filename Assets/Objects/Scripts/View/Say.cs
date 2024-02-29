using UnityEngine;
using Game.Dialogs;
using TMPro;

namespace Data.View
{
    public class Say: MonoBehaviour
    {
        [SerializeField] private Dialog _dialogs;

        private StraightReader _straightReader;
        private BranchedReader _brachedReader;

        public Dialog Dialogs
        {
            get
            {
                return _dialogs;
            }
            set
            {
                _dialogs = value;
            }
        }

        [SerializeField] private Reader _reader;
        public Reader Reader
        {
            get
            {
                return _reader;
            }
            set
            {
                _reader = value;
            }
        }

        [SerializeField] private Dialog _newDialogs;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _text;

        private int _index;

        private void Start ()
        {
            if(_dialogs != null) NextLine();

            //_straightReader = new StraightReader();
            //_brachedReader = new BrachedReader();
            _reader = _straightReader;
        }

        public void Clickreader()
        {
            _reader.NextLine();
        }

        public void ReturnReader()
        {
            Dialogs = _newDialogs;
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

