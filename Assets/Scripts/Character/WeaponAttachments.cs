using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachments : MonoBehaviour
{
    [SerializeField] Transform _weaponTransform;
    public bool isWeaponCreated { get; set;}

    private void Awake()
    {
        isWeaponCreated = false;
    }

    public void CreateWeapon(GameObject weapon)
    {
        Instantiate(weapon, _weaponTransform.transform.position, Quaternion.identity, this.transform);
        isWeaponCreated = true;
    }

    public void DestroyWeapon(GameObject weapon)
    {
        Destroy(weapon);
        isWeaponCreated = false;
    }
}
