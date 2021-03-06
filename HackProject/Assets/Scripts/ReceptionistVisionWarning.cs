﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ReceptionistVisionWarning : MonoBehaviour
{
    private GameObject warningIndicator;
    // Start is called before the first frame update
    void Start()
    {
        warningIndicator = transform.parent.GetChild(0).gameObject;
        warningIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Warn()
    {
        warningIndicator.SetActive(true);
    }

    private void Unwarn()
    {
        warningIndicator.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.CompareTag("Player"))
        {
            if (gObject.GetComponentInChildren<ChildHandler>().isEquipped)
                Warn();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.CompareTag("Player"))
        {
            Unwarn();
        }
    }
}
