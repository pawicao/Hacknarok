﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVisionEnd : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.CompareTag("Player1") || gObject.CompareTag("Player2"))
        {
                gameManager.EndGame(true);
        }
    }
}
