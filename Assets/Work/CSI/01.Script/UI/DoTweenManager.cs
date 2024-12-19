using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class DoTweenManager : MonoBehaviour
{
    public GameObject title;
    public GameObject btns;

    private void Start()
    {
        
            title.transform.GetComponent<RectTransform>().DOAnchorPosX(855, 0.4f).SetEase(Ease.Unset);
        btns.transform.GetComponent<RectTransform>().DOAnchorPosX(1342, 0.4f).SetEase(Ease.Unset);
        
    }
}
