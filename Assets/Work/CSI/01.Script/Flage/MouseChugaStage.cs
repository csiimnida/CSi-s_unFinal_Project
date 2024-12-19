using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseChugaStage : MonoBehaviour ,IRestartable
{
    public MouseStage mouseStage;
    public Image image;

    private void OnEnable()
    {
        if (mouseStage == MouseStage.AncurMouse)
        {
            FollowMouse.Instance.CanFollow = false;
        }else if (mouseStage == MouseStage.ScreenBlack)
        {
            StartCoroutine(ScreenBalckWait());
        }
    }


    IEnumerator ScreenBalckWait()
    {
        yield return new WaitForSecondsRealtime(1f);
        image.enabled = true;
    }
    private void OnDisable()
    {
        FollowMouse.Instance.CanFollow = true;
        if (mouseStage == MouseStage.ScreenBlack)
        {
            image.enabled = false;
        }

    }

    public enum MouseStage
    {
        AncurMouse,
        ScreenBlack,
        BlueScreenStage,
    }

    public void RestartSet()
    {
        StopCoroutine(ScreenBalckWait());
        if (mouseStage == MouseStage.AncurMouse)
        {
            FollowMouse.Instance.CanFollow = false;
        }else if (mouseStage == MouseStage.ScreenBlack)
        {
            image.enabled = false;
            StartCoroutine(ScreenBalckWait());
        }
    }

    public void RestartEnd()
    {
        
    }
}
