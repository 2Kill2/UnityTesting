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
    }

    

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Pos: " + " x: " + playerobject.transform.position.x + " y: " + playerobject.transform.position.y + " z: " + playerobject.transform.position.z); //add 5 second delay so it doesnt spam log
    }
}
