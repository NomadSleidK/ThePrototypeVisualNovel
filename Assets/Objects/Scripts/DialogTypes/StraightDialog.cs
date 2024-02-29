using UnityEngine;

namespace Game.Dialogs
{
    [CreateAssetMenu(menuName = "Dialogs/" + nameof(StraightDialog))]

    public class StraightDialog: Dialogs
    {
        [SerializeField] private StraightDialog _nextDialog;
        public StraightDialog NextDialog => _nextDialog;
    }
}
