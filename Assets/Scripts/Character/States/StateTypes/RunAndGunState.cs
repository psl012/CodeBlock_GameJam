using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAndGunState : IState
{
    const string ANIM_RUN_BOOL = "isRunning";

    CharacterAI _characterAI;

    public RunAndGunState(CharacterAI characterAI)
    {
        _characterAI = characterAI;
    }

    // Start is called before the first frame update
    public void Tick()
    {
        _characterAI.MoveRight();
        _characterAI.UseWeapon();
    }

    // Update is called once per frame
    public void OnEnter()
    {
        _characterAI._modelAnimator.SetBool(ANIM_RUN_BOOL, true);
        _characterAI.EquipWeapon();
    }

    public void OnExit()
    {

    }
}
