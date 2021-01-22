using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    const string ANIM_KILL_PLAYER_TRIGGER = "killPlayer";

    Animator _animator;
    CharacterSoundEffects _characterSoundEffects;

    public DeathState(Animator animator, CharacterSoundEffects characterSoundEffects)
    {
        _animator = animator;
        _characterSoundEffects = characterSoundEffects;
    }

    public void Tick() { }
    public void OnEnter()
    {
        _animator.SetTrigger(ANIM_KILL_PLAYER_TRIGGER);
        _characterSoundEffects.PlayDeathSound();
    }
    public void OnExit() { }
}
