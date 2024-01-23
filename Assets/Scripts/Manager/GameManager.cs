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
    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";
    public Animator PlayerAnimator;
    public Text PlayerName;
    [SerializeField] private int currentWaveIndex = 0;
    private int currentSpawnCount = 0;
    private int waveSpawnCount = 0;
    private int waveSpawnPosCount = 0;

    public float spawnInterval = 1.5f;
    public List<GameObject> enemyPrefebs = new List<GameObject>();

    [SerializeField] private Transform spawnPositionsRoot;
    private List<Transform> spawnPostions = new List<Transform>();



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Player = GameObject.FindGameObjectWithTag(playerTag).transform;
            for (int i = 0; i < spawnPositionsRoot.childCount; i++)
            {
                spawnPostions.Add(spawnPositionsRoot.GetChild(i));
            }
        }
        else Destroy(gameObject);
    }

    private void Start()
    {

    }

    IEnumerator StartNextWave()
    {
        while (true)
        {
            if (currentSpawnCount == 0)
            {
                yield return new WaitForSeconds(2f);
                waveSpawnPosCount = 6;
                waveSpawnCount = 5;

                for (int i = 0; i < waveSpawnPosCount; i++)
                {
                    int posIdx = UnityEngine.Random.Range(0, spawnPostions.Count);
                    for (int j = 0; j < waveSpawnCount; j++)
                    {
                        int prefabIdx = UnityEngine.Random.Range(0, enemyPrefebs.Count);
                        GameObject enemy = Instantiate(enemyPrefebs[prefabIdx], spawnPostions[posIdx].position, Quaternion.identity);
                        

                        currentSpawnCount++;
                        yield return new WaitForSeconds(spawnInterval);
                    }
                }

            }

            yield return null;
        }
    }

    public void Chase()
    {
        StartCoroutine("StartNextWave");
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
