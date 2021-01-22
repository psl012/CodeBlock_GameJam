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

    private void Awake()
    {
        currentHealth = initialHealth;
    }

    public void Damage(float damage)
    {
        if (isInvulnerable) return;

        currentHealth -= damage;
    }
}
