using Game.Data;
using UnityEngine;
using TMPro;

namespace Data.View
{
    public class Say: MonoBehaviour
    {
        [SerializeField] private Dialogs _dialogs; //���� ��� �������
        [SerializeField] private Dialogs _newDialogs; //���� ��� �������
        [SerializeField] private TextMeshProUGUI _name; //���� ������ �����
        [SerializeField] private TextMeshProUGUI _text; //���� ������ ������

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

