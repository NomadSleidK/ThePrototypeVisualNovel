using System.Collections;
using System.Collections.Generic;
using Game.Dialogs;
using UnityEngine;
using static UnityEditor.Progress;

public class ChoiceMenu : MonoBehaviour
{
    [SerializeField] private GameObject _choicePrefab;
    [SerializeField] private GameObject _choiceZone;
    private Choice _choice;
    private GameObject[] _choices;

    public string[] testArray;

    public void CreateNewChoices(ChoiceOption[] ChoiceOptions)
    {
        //_choices = new GameObject[ChoiceOptions.Length];
        //Debug.Log(ChoiceOptions.TextOption);       <-------
        foreach (ChoiceOption option in ChoiceOptions)
        {
            GameObject newOption = Instantiate(_choicePrefab);
            newOption.transform.SetParent(_choiceZone.transform);
            _choice = newOption.GetComponent<Choice>();
            _choice.ChoiceText.SetText(option.TextOption);
            _choice.NextDialog = option.Dialogs;
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
