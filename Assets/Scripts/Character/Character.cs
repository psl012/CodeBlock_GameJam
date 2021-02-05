using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected StateMachine _stateMachine;
    public Animator _modelAnimator { get; set; }
    public CharacterSoundEffects _characterSoundEffects{get; set;}

    protected Health _health;
    protected virtual void Awake()
    {
        _stateMachine = new StateMachine();
        _modelAnimator = GetComponentInChildren<Animator>();
        _characterSoundEffects = GetComponent<CharacterSoundEffects>();
        _health = GetComponent<Health>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void HitCharacter()
    {

    }


}
