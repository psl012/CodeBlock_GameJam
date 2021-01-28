﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelManager : MonoBehaviour
{
    public static UILevelManager instance;
    
    private void Awake()
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
   


}
