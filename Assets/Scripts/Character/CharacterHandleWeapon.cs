using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandleWeapon : MonoBehaviour
{
    public Weapon _weapon;
    public WeaponAttachments _weaponAttachments;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseWeapon()
    {
        _weapon.WeaponUse();
    }


}
