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
            canvas.transform as RectTransform, // �θ� Canvas�� RectTransform
            eventData.position,               // ���콺 ��ġ (Screen Point)
            canvas.worldCamera,               // ī�޶� (Screen Space - Camera ����� ��� �ʿ�)
            out Vector2 localPoint            // ��ȯ�� ���� ��ġ
        );

        localPoint += new Vector2(-50, 50);
        rectTransform.localPosition = localPoint;
    }
}
