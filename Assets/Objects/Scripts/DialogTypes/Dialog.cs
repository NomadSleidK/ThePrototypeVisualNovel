using UnityEngine;

namespace Game.Dialogs
{
    public class Dialog: ScriptableObject
    {
        
        [SerializeField] private GameObject _backGround;
        public GameObject BackGround => _backGround;
        

        [System.Serializable]
        public class Replica
        {
            [SerializeField] private string _name;
            [SerializeField] private string _text;

            public string Name => _name;
            public string Text => _text;
        }
        [SerializeField] private Replica[] _dialogs;

        public Replica[] Get => _dialogs;
    }
}
