﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Docs : MonoBehaviour, Interactable
{
    private bool done;
    private bool forgeInProgress;
    private TaskManager taskManager;
    public float moveTolerance;
    private RectTransform playerPosition;
    private Vector3 initialPosition;
    private Coroutine coroutine;

    private Vector3 screenPosition;
    private RectTransform indicatorPosition;
    private Image indicatorBar;
    private GameObject progressIndicator;
    private float startTime;
    
    public float timeToSucceed;
    public void Interact(InteractController controller) {
        Task task = taskManager.TaskExists(GameManager.TaskType.DOCUMENTS);
        if (task)
        {
            playerPosition = controller.gameObject.GetComponent<RectTransform>();
            initialPosition = playerPosition.position;
            if(!forgeInProgress)
                coroutine = StartCoroutine(Forge(task));
        }
        
        else
        {
            if (done)
            {
                Debug.Log("Dude, are you high?! You have already done that task!");
            }
            Debug.Log("Not now man! Now is not the time for that!");
        }
    }

    private void Succeed(Task task)
    {
        Debug.Log("Nice!");
        task.Accomplish();
        done = true;
    }
    
    void Start()
    {
        taskManager = TaskManager.instance;
        done = false;
        forgeInProgress = false;
        screenPosition = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().WorldToScreenPoint(transform.position);
        screenPosition.y += 17;
        progressIndicator = GameObject.Find("Desk Progress");
        indicatorPosition = progressIndicator.GetComponent<RectTransform>();
        indicatorPosition.position = screenPosition;
        indicatorBar = progressIndicator.GetComponent<Image>();
        indicatorBar.fillAmount = 1;
        progressIndicator.SetActive(false);
    }

    void Update()
    {
        if (forgeInProgress)
        {
            indicatorBar.fillAmount = 1 - (Time.time - startTime) / timeToSucceed;
            if (Vector2.Distance(playerPosition.position, initialPosition) > moveTolerance)
            {
                StopCoroutine(coroutine);
                progressIndicator.SetActive(false);
                indicatorBar.fillAmount = 1;
                forgeInProgress = false;
            }
        }
    }

    IEnumerator Forge(Task task)
    {
        startTime = Time.time;
        progressIndicator.SetActive(true);
        forgeInProgress = true;
        yield return new WaitForSeconds(timeToSucceed);
        Succeed(task);
        progressIndicator.SetActive(false);
    }
}
