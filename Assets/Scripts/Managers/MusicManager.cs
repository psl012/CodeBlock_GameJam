using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] AudioClip _deathSound;

    [Header("Background Music")]
    [SerializeField] AudioClip[] _musicSource;


    AudioSource _audioSource;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        _audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.instance.onPlayerDeath += DeathMusic;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex; 
        StartMusic(sceneNumber);
    }

    void StartMusic(int musicNumber)
    {
        _audioSource.clip = _musicSource[musicNumber];
        _audioSource.Play();
        _audioSource.loop = true;
    }

    void DeathMusic()
    {
        _audioSource.clip = _deathSound;
        _audioSource.Play();
        _audioSource.loop = false;
        Debug.Log("Count!");
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
