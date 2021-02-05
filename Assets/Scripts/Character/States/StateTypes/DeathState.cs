using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    const string ANIM_KILL_PLAYER_TRIGGER = "killPlayer";
    Character _character;    

    public DeathState(Character character)
    {
        _character = character;
    }

    public void Tick() { }
    public void OnEnter()
    {
        KillCharacter();
        if (_character.tag == "Player") LevelManager.instance.PlayerDeath();
    }
    public void OnExit() { }

    public void KillCharacter()
    {        
        _character._modelAnimator?.SetTrigger(ANIM_KILL_PLAYER_TRIGGER);
        _character._characterSoundEffects?.PlayDeathSound();
    }
}
