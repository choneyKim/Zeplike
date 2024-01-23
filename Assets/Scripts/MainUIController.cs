using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class MainUIController : MonoBehaviour
{
    [SerializeField] private Text PlayerName;
    [SerializeField] private InputField InputField;
    [SerializeField] private GameObject ReNamePop;
    [SerializeField] private GameObject selectCharacterPop;
    [SerializeField] private GameObject talkabout;


    private CharacterType characterType;

    public void MainSelectCharacter()
    {
        selectCharacterPop.SetActive(true);
    }
    public void MainReNamePop()
    {
        ReNamePop.SetActive(true);
    }
    public void OnClickSelectCharacter(int index)
    {
        characterType = (CharacterType)index;
        var character = GameManager.Instance.CharacterList.Find(x => x.CharacterType == characterType);
        GameManager.Instance.PopUpSetCharacter(characterType);

        selectCharacterPop.SetActive(false);
    }

    public void SelectEnter()
    {
        if (InputField.text.Length < 2 || InputField.text.Length > 10) return;
        GameManager.Instance.PopUpReName(InputField.text);

        ReNamePop.SetActive(false);
    }

    public void SelectTalk()
    {
            talkabout.SetActive(true);

    }
    private void FixedUpdate()
    {
        if (talkabout && UnityEngine.Input.anyKey)
        {
            talkabout.SetActive(false);

        }
    }


}
