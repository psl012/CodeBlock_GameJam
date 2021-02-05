using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    const string ANIM_KILL_PLAYER_TRIGGER = "killPlayer";
    CharacterAI _characterAI;    

    public DeathState(CharacterAI characterAI)
    {
        _characterAI = characterAI;
    }

    public void Tick() { }
    public void OnEnter()
    {
        KillCharacter();
        LevelManager.instance.PlayerDeath();
    }
    public void OnExit() { }

    public void KillCharacter()
    {        
        _characterAI._modelAnimator?.SetTrigger(ANIM_KILL_PLAYER_TRIGGER);
        _characterAI._characterSoundEffects?.PlayDeathSound();
    }
}
