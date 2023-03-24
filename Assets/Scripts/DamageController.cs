using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int trapDamage;

    [SerializeField] private PlayerHealth _playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        _playerHealth.playerHealth = _playerHealth.playerHealth - trapDamage;
        _playerHealth.UpdateHealth();
        
    }

}
