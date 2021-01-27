using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponEffects : MonoBehaviour
{
    Weapon _weapon;

    [SerializeField] AudioClip _fireEffect;
    AudioSource _audioSource;

    public event Action onUseEffect = delegate { };

    void Awake()
    {
        _weapon = GetComponentInParent<Weapon>();
        _audioSource = GetComponent<AudioSource>();
        onUseEffect += SoundEffect;
    }

    public void UseEffect()
    {
        onUseEffect();
    }

    void SoundEffect()
    {
        _audioSource.clip = _fireEffect;
        _audioSource.Play();
    }
}
