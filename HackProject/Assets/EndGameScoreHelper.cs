﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScoreHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Score.instance.ChangeScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
