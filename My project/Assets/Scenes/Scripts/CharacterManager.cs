using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Charactermanager : MonoBehaviour
{
    private GameObject playerobject;
    // Start is called before the first frame update
    void Start()
    {
        playerobject = this.gameObject;
        Debug.Log("Player object set to: " + playerobject.name);
        Debug.Log(playerobject.transform.position.x + playerobject.transform.position.y + playerobject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
