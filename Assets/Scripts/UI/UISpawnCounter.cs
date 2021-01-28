using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISpawnCounter : MonoBehaviour
{
    const string SPAWN_STRING = "Respawn Count: ";

    TextMeshProUGUI _textMeshProUGUI;

    void Awake()
    {
        _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        LevelManager.instance.onRestartLevel += UpdateSpawnCounter;
    }

    
    void UpdateSpawnCounter()
    {
        _textMeshProUGUI.text = SPAWN_STRING + LevelManager.instance.respawnCount;
    }

    
}
