using System.Collections;
using System.Collections.Generic;
using Game.Dialogs;
using UnityEngine;
using static UnityEditor.Progress;

public class ChoiceMenu : MonoBehaviour
{
    [SerializeField] private GameObject _choicePrefab;
    [SerializeField] private GameObject _choiceZone;
    private OptionBox _optionBox; //переменная скрипта кнопки выбора
    private GameObject[] _choices; //массив ссылок на кнопоки

    public void CreateNewChoices(ChoiceOption[] ChoiceOptions)
    {
        _choices = new GameObject[ChoiceOptions.Length];
        foreach (ChoiceOption option in ChoiceOptions)
        {
            GameObject newOption = Instantiate(_choicePrefab);
            newOption.transform.SetParent(_choiceZone.transform);
            _optionBox = newOption.GetComponent<OptionBox>();
            _optionBox.OptionBoxText.SetText(option.TextOption);
            _optionBox.NextDialog = option.NextDialog;
        }
    }

    private void DeleteChoices()
    {
        foreach (GameObject option in _choices)
        {
            Destroy(option);
        }
        _choices = null;
    }
}
