﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    bool isUsed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isUsed)
        {
            isUsed = true;
            collision.GetComponent<CharacterAI>().Jump();
        }
    }

}
