using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplay : MonoBehaviour
{
    public float Health, MaxHealth, Width, Height;

    [SerializeField] private RectTransform healthBar;
    [SerializeField] private HealthSystem healthSystem;

    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        Health = health;
        float newWidth = Health / MaxHealth * Width;

        healthBar.sizeDelta = new Vector2(newWidth, Height);
    }



}
