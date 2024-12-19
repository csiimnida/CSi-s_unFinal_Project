using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackBtn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform target;
    [SerializeField] private float distance;

    private RectTransform _thisRectTrm;

    private void Awake()
    {
        _thisRectTrm = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Vector2.Distance(target.anchoredPosition, _thisRectTrm.anchoredPosition) < distance)
        {
            transform.GetComponentInParent<Stage>().Clear();
        }
    }
}
