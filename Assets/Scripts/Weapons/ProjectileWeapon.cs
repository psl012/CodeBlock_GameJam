using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    WeaponEffects _weaponEffects;
    WeaponAttachments _weaponAttachments;

    public float _shotDelay;
    public bool _isDestroyObjectOnEmpty;

    float shotDelayHold;

    private void Awake()
    {
        shotDelayHold = _shotDelay;
        _weaponEffects = GetComponentInChildren<WeaponEffects>();
        _weaponAttachments = GetComponentInParent<WeaponAttachments>();
    }

    public override void WeaponUse()
    {
        base.WeaponUse();
        if (_magazineSize <= 0)
        {
            return;
        }

        if (_shotDelay > 0)
        {
            _shotDelay -= Time.deltaTime;
        }
        else
        {
            _shotDelay = shotDelayHold;
            RifleFire();
        }

    }

    void RifleFire()
    {
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        _magazineSize -= _ammoConsumedPerShot;
        _weaponEffects?.UseEffect();

        if (_isDestroyObjectOnEmpty && _magazineSize <= 0)
        {
            Debug.Log(_weaponAttachments);
            _weaponAttachments.DestroyWeapon(this.gameObject);
        }
    }




 
    
}
