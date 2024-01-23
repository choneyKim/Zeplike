using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterType
{
    Devil,
    Zombie
}
[Serializable]
public class Character
{
    public CharacterType CharacterType;
    public Sprite CharacterSprite;
    public RuntimeAnimatorController AnimatorController;
}


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Character> CharacterList = new List<Character>();

    public Animator PlayerAnimator;
    public Text PlayerName;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }
    public void StartSetCharacter(CharacterType characterType, string name)
    {
        var character = GameManager.Instance.CharacterList.Find(x => x.CharacterType == characterType);

        PlayerAnimator.runtimeAnimatorController = character.AnimatorController;
        PlayerName.text = name;
    }
    public void PopUpSetCharacter(CharacterType characterType)
    {
        var character = GameManager.Instance.CharacterList.Find(x => x.CharacterType == characterType);

        PlayerAnimator.runtimeAnimatorController = character.AnimatorController;
    }
    public void PopUpReName(string name)
    {

        PlayerName.text = name;
    }
}
