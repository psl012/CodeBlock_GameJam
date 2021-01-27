using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePickup : MonoBehaviour
{
    [SerializeField] GameObject _rifleWeapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponAttachments weaponAttachments = collision.gameObject.GetComponent<CharacterHandleWeapon>()._weaponAttachments;
        weaponAttachments?.CreateWeapon(_rifleWeapon);
        Destroy(gameObject);
    }
}
