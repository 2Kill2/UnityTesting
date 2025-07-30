using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlexScripts;

/// <Summary>
/// MonoBehaviour that only exists while the game is in play
/// </Summary>
public class PlayerLocatorSingleton : MonoBehaviour
{
    /// <summary>
    /// Static field that exists for the entire project's duration
    /// IMPORTANT! can be null if the game is not playing!
    /// </summary>
    public static PlayerLocatorSingleton Instance;

    private void Awake()
    {
        // Instance will be null only if no PlayerLocator GameObject exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is more than one PlayerLocatorSingleton");
            Destroy(gameObject);
        }
    }
}
