using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [field:SerializeField]public InputReader _InputReader{get; private set;}

    [SerializeField]private float TimerMax;
    private float timer;
    private bool StartTimer;
    private Vector2 Mousepos;
    private void Start()
    {
        _InputReader.OnMouseMoveEvent += HandleMouseMove;
    }

    private void Update()
    {
        if (StartTimer)
        {
            timer += Time.deltaTime;
            if (timer > TimerMax)
            {
                StartTimer = false;
                timer = 0;
                if (Mousepos == Vector2.zero)
                {
                    Debug.Log("Stop");
                }
            }
        }
    }

    private void HandleMouseMove(Vector2 obj)
    {
        Mousepos = obj;
        StartTimer = true;
        timer = 0;
    }
}
