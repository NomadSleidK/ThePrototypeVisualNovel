using UnityEngine;
using System.Collections.Generic;
using System;

namespace Game.Dialogs
{
    [Serializable]

    [CreateAssetMenu(menuName = "Dialogs/" + nameof(BranchedDialog))]

    public class BranchedDialog: Dialog
    {
        [SerializeField] private ChoiceOption[] _choiceOptions;
        public ChoiceOption[] GetNextOptions => _choiceOptions;

    }
}
