using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Character
{
    const string ANIM_KILL_PLAYER_TRIGGER = "killPlayer";
    public Animator _modelAnimator { get; private set; }

    Health _health;
    CharacterSoundEffects _characterSoundEffects;

    bool isDead = false;

    private void Awake()
    {
        _modelAnimator = GetComponentInChildren<Animator>();
        _health = GetComponent<Health>();
        _characterSoundEffects = GetComponent<CharacterSoundEffects>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_health.currentHealth > 0)
        {
            return;
        }

        if (!isDead)
        {
            isDead = true;
            _modelAnimator.SetTrigger(ANIM_KILL_PLAYER_TRIGGER);
        }
        
    }

    public override void HitCharacter()
    {
        base.HitCharacter();
        _characterSoundEffects?.PlayHitSound();
    }


}
