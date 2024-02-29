using UnityEngine;
using System.Collections.Generic;
using System;

namespace Game.Dialogs
{
    [Serializable]

    public class ChoiceOption
    {
        [SerializeField] private string _textOption;
        public string TextOption => _textOption;

        [SerializeField] private StraightDialog _dialog;
        public StraightDialog Dialogs => _dialog;
    }

    [CreateAssetMenu(menuName = "Dialogs/" + nameof(BranchedDialog))]

    public class BranchedDialog: Dialogs
    {
        [SerializeField] private ChoiceOption[] _choiceOptions;
        public ChoiceOption[] GetNextOptions => _choiceOptions;

    }
}
