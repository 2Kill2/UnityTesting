using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplay : MonoBehaviour
{
    public float Width = 300f;
    public float Height = 40f;
    public float Health, MaxHealth;

    [SerializeField] private RectTransform healthBar;
    [SerializeField] private HealthSystem healthSystem;

    private float maxHealth;
    private void Start()
    {
        if (healthSystem == null)
        {
            healthSystem = GetComponent<HealthSystem>();
        }
        maxHealth = healthSystem.GetMaxHealth();
    }

    private void Update()
    {
        if (healthSystem != null)
        {
            Health = healthSystem.GetCurrentHealth();
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            float healthPercentage = Health / maxHealth;
            healthBar.sizeDelta = new Vector2(Width * healthPercentage, Height);
        }
    }

}
