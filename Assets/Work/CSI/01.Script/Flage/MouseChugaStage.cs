using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChugaStage : MonoBehaviour ,IRestartable
{
    public MouseStage mouseStage;


    private void OnEnable()
    {
        if (mouseStage == MouseStage.AncurMouse)
        {
            FollowMouse.Instance.CanFollow = false;
        }
    }

    private void OnDisable()
    {
        FollowMouse.Instance.CanFollow = true;
    }

    public enum MouseStage
    {
        AncurMouse,
        BlueScreenStage,
    }

    public void RestartSet()
    {
        
    }

    public void RestartEnd()
    {
        
    }
}
