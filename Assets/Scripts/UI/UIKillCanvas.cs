using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKillCanvas : MonoBehaviour
{


    private void Awake()
    {
    }

    private void Start()
    {
        LevelManager.instance.onPlayerDeath += ActivateCanvas;
        LevelManager.instance.onRestartLevel += DeactivateCanvas;
        DeactivateCanvas();
    }

    public void ActivateCanvas()
    {
        gameObject.SetActive(true);

    }

    public void DeactivateCanvas()
    {

        gameObject.SetActive(false);
    }
}
