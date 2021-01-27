using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Characteristics")]
    [Tooltip("Name of the weapon used for debugging")]
    public string _weaponName;

    [Tooltip("the size of the magazine")]
    public int _magazineSize;

    [Tooltip("amount of ammo consumed per use")]
    public int _ammoConsumedPerShot;

    [Tooltip("Bullet Prefab")]
    public GameObject _bulletPrefab;

    [Tooltip("a transform to use as the spawn point for weapon use (if null, only offset will be considered, otherwise the transform without offset)")]
    public Transform WeaponUseTransform;



    public virtual void WeaponUse()
    {

    }
}
