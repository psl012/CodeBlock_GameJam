using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    CharacterAI _characterAI;

    public DeathState(CharacterAI characterAI)
    {
        _characterAI = characterAI;
    }

    public void Tick() { }
    public void OnEnter()
    {
        _characterAI.KillCharacter();
    }
    public void OnExit() { }
}
