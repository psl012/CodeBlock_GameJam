using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public LayerMask TargetLayerMask;
    public int _damageTakenEveryTime;

    [SerializeField] protected float _damageAmount;

    Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("sd");
        collision.GetComponent<Health>().Damage(_damageAmount);
        Debug.Log(collision.GetComponent<Health>().currentHealth);
        SelfDamage(_damageTakenEveryTime);
    }

    public void SelfDamage(float damage)
    {
        _health?.Damage(damage);
    }
}
