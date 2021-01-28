using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Parameters")]
    public float initialHealth;
    public float currentHealth;
    public float maximumhealth;

    [Header("Status")]
    public bool isInvulnerable;

    [Header("Death Parameters")]
    public bool _isDestroyOnDeath;
    public float _delayTillDestroy;

    public bool _isDisableColliderOnDeath;
    public float _delayTilldDisable;

    Collider2D _collider2D;

    Character _character;

    private void Awake()
    {
        currentHealth = initialHealth;
        _collider2D = GetComponent<Collider2D>();

    }

    private void Start()
    {
        _character = GetComponent<Character>();
    }

    public void Damage(float damage)
    {
        _character?.HitCharacter(); // BUg on Rifle becuase it is not a character
        if (isInvulnerable) return;

        currentHealth -= damage;

        if (_isDestroyOnDeath && currentHealth <= 0)
        {
            Destroy(gameObject, _delayTillDestroy);
        }

        if (_isDisableColliderOnDeath && currentHealth <= 0)
        {
            _collider2D.enabled = false;
        }
    }


    


    

}
