using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject _playerInput;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Charactermanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
