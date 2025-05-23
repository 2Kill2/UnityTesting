using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadLevelAdditively(string levelName)
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
    }

}
