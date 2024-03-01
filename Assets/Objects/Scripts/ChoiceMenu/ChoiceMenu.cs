using System.Collections;
using System.Collections.Generic;
using Game.Dialogs;
using UnityEngine;

public class ChoiceMenu : MonoBehaviour
{
    [SerializeField] private GameObject _choicePrefab;
    [SerializeField] private GameObject _choiceZone;
    private OptionBox _optionBox;


    public void CreateNewChoices(ChoiceOption[] ChoiceOptions)
    {
        foreach (ChoiceOption option in ChoiceOptions)
        {
            GameObject newOption = Instantiate(_choicePrefab);
            newOption.transform.SetParent(_choiceZone.transform);
            _optionBox = newOption.GetComponent<OptionBox>();
            _optionBox.OptionBoxText.SetText(option.TextOption);
            _optionBox.NextDialog = option.NextDialog;
        }
    }

    public void DeleteChoices()
    {
        while (_choiceZone.transform.childCount > 0)
            DestroyImmediate(_choiceZone.transform.GetChild(0).gameObject);

        this.gameObject.SetActive(false);
    }
}
