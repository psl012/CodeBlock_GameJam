using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour
{
    const string ANIM_KILL_PLAYER_TRIGGER = "killPlayer";

    StateMachine _stateMachine;

    public Animator _modelAnimator { get; private set; }

    Character _character;
    CharacterMovement _characterMovement;
    CharacterJump _characterJump;
    CharacterHandleWeapon _characterHandleWeapon;
    CharacterSoundEffects _characterSoundEffects;
    Weapon _weapon;
    Health _health;


    private void Awake()
    {
        Initialize();

        HandleInitialze();

        var runningState = new RunningState(this);
        var deathState = new DeathState(this);
        var runAndGunState = new RunAndGunState(this);

        At(runningState, deathState, PlayerDead());
        At(runningState, runAndGunState, isEquipWeapon());
        At(runAndGunState, runningState, isWeaponDestroyed());

        _stateMachine.SetState(runningState);

        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);

        Func<bool> StageStart() => () => true;
        Func<bool> PlayerDead() => () => _health.currentHealth <= 0;
        Func<bool> isEquipWeapon() => () => _characterHandleWeapon._weaponAttachments.isWeaponCreated;
        Func<bool> isWeaponDestroyed() => () => !_characterHandleWeapon._weaponAttachments.isWeaponCreated;
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
    }

    

    public void MoveRight()
    {
        _characterMovement?.MoveRight();
    }

    public void Jump()
    {
        _characterJump?.Jump();
        _characterSoundEffects?.PlayJumpSound();
    }

    public void KillCharacter()
    {
        _modelAnimator?.SetTrigger(ANIM_KILL_PLAYER_TRIGGER);
        _characterSoundEffects?.PlayDeathSound();
    }


    public void EquipWeapon()
    {
        _weapon = _characterHandleWeapon._weaponAttachments.GetComponentInChildren<Weapon>();
    }

    public void UseWeapon()
    {
        _weapon?.WeaponUse();
    }

    void Initialize()
    {
        _stateMachine = new StateMachine();

        _characterMovement = GetComponent<CharacterMovement>();
        _characterJump = GetComponent<CharacterJump>();
        _characterHandleWeapon = GetComponent<CharacterHandleWeapon>();
        _health = GetComponent<Health>();
        _modelAnimator = GetComponentInChildren<Animator>();
        _characterSoundEffects = GetComponent<CharacterSoundEffects>();
    }

    void HandleInitialze()
    {
        if (_characterJump == null) Debug.LogWarning("_characterJump is NULL!");
        if (_characterMovement == null) Debug.LogWarning("_characterMovement is NULL!");
    }
}
