using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour
{

    StateMachine _stateMachine;

    Character _character;
    CharacterMovement _characterMovement;
    CharacterJump _characterJump;
    Health _health;
    CharacterSoundEffects _characterSoundEffects;

    [Header("Field Attributes")]
    [SerializeField] Animator _modelAnimator;
 


    private void Awake()
    {
        _stateMachine = new StateMachine();

        _characterMovement = GetComponent<CharacterMovement>();
        _characterJump = GetComponent<CharacterJump>();
        _health = GetComponent<Health>();
        _modelAnimator = GetComponentInChildren<Animator>();
        _characterSoundEffects = GetComponent<CharacterSoundEffects>();
               

        HandleInitialze();

        var runningState = new RunningState(_characterMovement, _characterJump, _modelAnimator);
        var DeathState = new DeathState(_modelAnimator, _characterSoundEffects);          

        At(runningState, DeathState, PlayerDead());

        _stateMachine.SetState(runningState);

        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);

        Func<bool> StageStart() => () => true;
        Func<bool> PlayerDead() => () => _health.currentHealth <= 0;
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
    }

    void HandleInitialze()
    {
        if (_characterJump == null) Debug.LogWarning("_characterJump is NULL!");
        if (_characterMovement == null) Debug.LogWarning("_characterMovement is NULL!");
    }

    public void Jump()
    {
        _characterJump.Jump();
        _characterSoundEffects.PlayJumpSound();
    }

}
