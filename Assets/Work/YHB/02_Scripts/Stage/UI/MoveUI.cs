using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveUI : MonoBehaviour, IRestartable, IDragHandler
{
    private RectTransform rectTransform;
    private Vector3 _startPos;
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        _startPos = rectTransform.anchoredPosition;
    }

    public void RestartSet()
    {
        rectTransform.anchoredPosition = _startPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, // 부모 Canvas의 RectTransform
            eventData.position,               // 마우스 위치 (Screen Point)
            canvas.worldCamera,               // 카메라 (Screen Space - Camera 모드일 경우 필요)
            out Vector2 localPoint            // 변환된 로컬 위치
        );

        localPoint += new Vector2(-50, 50);
        rectTransform.localPosition = localPoint;
    }
}
