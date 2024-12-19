using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Mouse : MonoBehaviour,IRestartable
{
    [field:SerializeField]public InputReader _InputReader{get; private set;}

    [SerializeField]private float TimerMax;
    private float timer;
    private bool StartTimer;
    private Vector2 Mousepos;
    public Action Move;
    public Action Stop; 
    private bool cooltimefree;
    
    private void Start()
    {
        _InputReader.OnMouseMoveEvent += HandleMouseMove;
    }


    private void Update()
    {
        if (!StartTimer) return;
        
            timer += Time.deltaTime;
            if (timer > TimerMax)
            {
                StartTimer = false;
                timer = 0;
                if (Mathf.Abs(Mousepos.x) < Mathf.Epsilon && Mathf.Abs(Mousepos.y) < Mathf.Epsilon)
                {
                    Stop?.Invoke();
                    Debug.Log("Stop");
                }
                else
                {
                    Move?.Invoke();
                    Debug.Log("Move");
                }                    

                
        }
    }

    private void HandleMouseMove(Vector2 obj)
    {
        if(!cooltimefree) return;
            Mousepos = obj;
            StartTimer = true;
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(0.2f);
        cooltimefree = true;
    }

    public void RestartSet()
    {
        cooltimefree = false;
        StartCoroutine(CoolTime());
    }

    public void RestartEnd()
    {
        //throw new NotImplementedException();
    }
}
