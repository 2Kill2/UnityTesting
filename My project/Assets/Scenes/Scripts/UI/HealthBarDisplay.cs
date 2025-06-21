using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplay : MonoBehaviour
{
    [SerializeField] private Image HealthBarFill;
    [SerializeField] private HealthSystem healthSystem;

    public void UpdateHP(float hpPercent)
    {
        HealthBarFill.fillAmount = Mathf.Clamp(hpPercent, 0f, 1f);
    }


}
