using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : IState
{
    const string ANIM_RUN_BOOL = "isRunning";

    AI_Player _characterAI;
    CharacterMovement _characterMovement;

    public RunningState(AI_Player characterAI)
    {
        _characterAI = characterAI;
        _characterMovement = _characterAI.GetComponent<CharacterMovement>();
    }
    
    // Start is called before the first frame update
    public void Tick()
    {
        MoveRight();
    }

    // Update is called once per frame
    public void OnEnter()
    {
        _characterAI._modelAnimator.SetBool(ANIM_RUN_BOOL, true);
    }

    public void OnExit()
    {

    }

    public void MoveRight()
    {
        _characterMovement?.MoveRight();
    }
        
}
