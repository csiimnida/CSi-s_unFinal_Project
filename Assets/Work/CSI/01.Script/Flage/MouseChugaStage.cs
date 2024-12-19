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

    }


    IEnumerator ScreenBalckWait()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        image.enabled = true;
    }
    IEnumerator ScreenBlueWait()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        image.gameObject.SetActive(true);
    }
    
    private void OnDisable()
    {
        FollowMouse.Instance.CanFollow = true;
        if (mouseStage == MouseStage.ScreenBlack)
        {
            image.enabled = false;
        }
        else if(mouseStage == MouseStage.BlueScreenStage)
        {
            image.gameObject.SetActive(false);
        }

    }
//그리고 성공 후 꺼야하는데 
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
            //FollowMouse.Instance.CanFollow = false;
        }else if (mouseStage == MouseStage.ScreenBlack)
        {
            image.enabled = false;

            StartCoroutine(ScreenBalckWait());
        }else if (mouseStage == MouseStage.BlueScreenStage)
        {
            image.gameObject.SetActive(false);

            StartCoroutine(ScreenBlueWait());
        }
    }
}
