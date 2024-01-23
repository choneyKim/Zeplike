using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    [SerializeField] private Image characterSprite;
    [SerializeField] private Text PlayerName;
    [SerializeField] private InputField InputField;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject selectCharacter;

    private CharacterType characterType;

    public void SelectCharacter()
    {
        startMenu.SetActive(false);
        selectCharacter.SetActive(true);
    }
    public void OnClickSelectCharacter(int index)
    {
        characterType = (CharacterType)index;
        var character = GameManager.Instance.CharacterList.Find(x=>x.CharacterType== characterType);
        characterSprite.sprite = character.CharacterSprite;
        characterSprite.SetNativeSize();

        startMenu.SetActive(true);
        selectCharacter.SetActive(false);
    }

    public void SelectJoin()
    {
        if (InputField.text.Length < 2 || InputField.text.Length > 10) return;
        GameManager.Instance.StartSetCharacter(characterType, InputField.text);

        Destroy(gameObject);
    }
    
}
