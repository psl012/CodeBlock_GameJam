using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Player : Character
{
    public CharacterMovement _characterMovement{get; set;}
    CharacterJump _characterJump;
    public CharacterHandleWeapon _characterHandleWeapon{get; set;}
    protected override void Awake()
    {
        base.Awake();
        Initialize();

        HandleInitialze();

        var runningState = new RunningState(this);
        var deathState = new DeathState(this);
        var runAndGunState = new RunAndGunState(this);

        At(runningState, deathState, PlayerDead());
        At(runningState, runAndGunState, isEquipWeapon());
        At(runAndGunState, runningState, isWeaponDestroyed());
        At(runAndGunState, deathState, PlayerDead());

        _stateMachine.SetState(runningState);

        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);

      //  Func<bool> StageStart() => () => true;
        Func<bool> PlayerDead() => () => _health.currentHealth <= 0;
        Func<bool> isEquipWeapon() => () => _characterHandleWeapon._weaponAttachments.isWeaponCreated;
        Func<bool> isWeaponDestroyed() => () => !_characterHandleWeapon._weaponAttachments.isWeaponCreated;
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
    }

    // Invariants
    public void Jump()
    {
        _characterJump?.Jump();
        _characterSoundEffects?.PlayJumpSound();
    }

    void Initialize()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _characterJump = GetComponent<CharacterJump>();
        _characterHandleWeapon = GetComponent<CharacterHandleWeapon>();
    }

    void HandleInitialze()
    {
        if (_characterJump == null) Debug.LogWarning("_characterJump is NULL!");
        if (_characterMovement == null) Debug.LogWarning("_characterMovement is NULL!");
    }
}
