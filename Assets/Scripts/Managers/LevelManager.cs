using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public event Action onRestartLevel = delegate { };
    public event Action onPlayerDeath = delegate { };

    public int respawnCount { get; private set; } = 0;

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
 
    }

    void Start()
    {
    }

    public void PlayerDeath()
    {
        onPlayerDeath();
    }
    
    public void RestartLevel()
    {
        respawnCount += 1;
        onRestartLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
 

    }
    




}
