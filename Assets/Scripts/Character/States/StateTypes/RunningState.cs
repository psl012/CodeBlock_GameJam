using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : IState
{
    const string ANIM_RUN_BOOL = "isRunning";

    CharacterMovement _characterMovement;
    CharacterJump _characterJump;
    Animator _animator;

    public RunningState(CharacterMovement characterMovement, CharacterJump characterJump, Animator animator)
    {
        _characterMovement = characterMovement;
        _characterJump = characterJump;
        _animator = animator;
    }
    
    // Start is called before the first frame update
    public void Tick()
    {
        _characterMovement.MoveRight();
    }

    // Update is called once per frame
    public void OnEnter()
    {
        _animator.SetBool(ANIM_RUN_BOOL, true);
    }

    public void OnExit()
    {

    }
        
}
