using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public float health, maxHealth;
    private void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            health = 0;
            OnPlayerDeath?.Invoke();
            
        }
    }
}
