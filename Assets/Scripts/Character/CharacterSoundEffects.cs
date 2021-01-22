using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterSoundEffects : MonoBehaviour
{
    [SerializeField] AudioClip _jumpSoundEffect;
    [SerializeField] AudioClip _deathSoundEffect;

    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        _audioSource.clip = _jumpSoundEffect;
        _audioSource.Play();
    }

    public void PlayDeathSound()
    {
        _audioSource.clip = _deathSoundEffect;
        _audioSource.Play();
    }
}
