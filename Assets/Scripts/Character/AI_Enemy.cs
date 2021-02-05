using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enemy : Character
{
    const string ANIM_KILL_PLAYER_TRIGGER = "killPlayer";

    protected override void Awake()
    {
        base.Awake();

        var idleState = new IdleState();
        var deathState = new DeathState(this);

        At(idleState, deathState, IsCharacterDead());

        _stateMachine.SetState(idleState);

        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
        Func<bool> IsCharacterDead() => () => _health.currentHealth <= 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
    }

    // Invariant
    public override void HitCharacter()
    {
        base.HitCharacter();
        _characterSoundEffects?.PlayHitSound();
    }


}
