using UnityEngine;

namespace Game.Dialogs
{

    public class Dialogs: ScriptableObject
    {
        [System.Serializable]
        public class Dialog
        {
            [SerializeField] private string _name;
            [SerializeField] private string _text;

            public string Name => _name;
            public string Text => _text;
        }
        [SerializeField] private Dialog[] _dialogs;

        public Dialog[] Get => _dialogs;
    }
}
