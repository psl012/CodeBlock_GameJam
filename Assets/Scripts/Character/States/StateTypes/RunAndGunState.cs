using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAndGunState : IState
{
    const string ANIM_RUN_BOOL = "isRunning";

    CharacterAI _characterAI;
    CharacterMovement _characterMovement;
    CharacterHandleWeapon _characterHandleWeapon;

    Weapon _weapon;

    public RunAndGunState(CharacterAI characterAI)
    {
        _characterAI = characterAI;
        _characterHandleWeapon = _characterAI._characterHandleWeapon; 
        _characterMovement = _characterAI._characterMovement;    
    }

    // Start is called before the first frame update
    public void Tick()
    {
        MoveRight();
        UseWeapon();
    }

    // Update is called once per frame
    public void OnEnter()
    {
        _characterAI._modelAnimator.SetBool(ANIM_RUN_BOOL, true);
        EquipWeapon();
    }

    public void OnExit()
    {

    }    
    public void MoveRight()
    {
        _characterMovement?.MoveRight();
    }

    public void EquipWeapon()
    {
        _weapon = _characterHandleWeapon._weaponAttachments.GetComponentInChildren<Weapon>();
    }

    public void UseWeapon()
    {
        _weapon?.WeaponUse();
    }
}
