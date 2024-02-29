using UnityEngine;

namespace Game.Dialogs
{
    [CreateAssetMenu(menuName = "Dialogs/" + nameof(StraightDialog))]

    public class StraightDialog: Dialog
    {
        [SerializeField] private Dialog _dialog;
        public Dialog NextDialog => _dialog;
    }
}
