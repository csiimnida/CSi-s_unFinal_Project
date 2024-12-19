using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStageClaerManager : MonoBehaviour,IRestartable
{
    
    [SerializeField] private MouseStageClaerType mouseStageClaerType;
    private Mouse _mouse;
    private Stage _stage;
    
    private void Awake()
    {
        _mouse = transform.parent.GetComponentInChildren<Mouse>();
        _stage = GetComponentInParent<Stage>();
        _mouse.Move += HandleMove;
        _mouse.Stop += HandleStop;
    }

    private void HandleMove()
    {
        if (mouseStageClaerType == MouseStageClaerType.DontMove)
        {
            Debug.Log("실패");
            _stage.Restart();
        }else if (mouseStageClaerType == MouseStageClaerType.Move)
        {
            Debug.Log("성공");

            _stage.Clear();
        }
        else
        {
            Debug.Log(mouseStageClaerType);
        }
    }
    private void HandleStop()
    {
        if (mouseStageClaerType == MouseStageClaerType.DontMove)
        {
            Debug.Log("성공");

            _stage.Clear();
        }else if (mouseStageClaerType == MouseStageClaerType.Move)
        {
            Debug.Log("실패");

            _stage.Restart();
        }
        else
        {
            Debug.Log(mouseStageClaerType);

        }
    }

    public void RestartSet()
    {
        
    }

    private void OnDisable()
    {
        _mouse.Move -= HandleMove;
        _mouse.Stop -= HandleStop;
    }


    enum MouseStageClaerType
    {
        DontMove,
        Move,
    }
}
