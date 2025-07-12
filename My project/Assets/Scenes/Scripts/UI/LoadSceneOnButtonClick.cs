using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnButtonClick : MonoBehaviour
{

    public void LoadScene()
    {
        Debug.Log("Loading scene...");
        SceneManager.LoadScene("SimpleLevel");

    }

}
