using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    [SerializeField] private Charactermanager characterManager;
    [SerializeField] private LevelManager levelManager;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        initializeGame();
    }

    private void initializeGame()
    {
        levelManager.LoadLevelAdditively("SimpleLeve");
        characterManager.SpawnCharacter();
    }
    
}
