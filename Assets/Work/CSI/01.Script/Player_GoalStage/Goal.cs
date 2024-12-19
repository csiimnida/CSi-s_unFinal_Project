using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))] 

public class Goal : MonoBehaviour ,IRestartable
{
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        transform.GetComponentInParent<Stage>().Clear();
    }

    public void RestartSet()
    {
        transform.position = startPosition;

    }

    public void RestartEnd()
    {
        
    }
}
