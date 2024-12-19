using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionUI : MonoBehaviour, IRestartable
{
    [SerializeField] private RectTransform target;
    [SerializeField] private float distance;

    private RectTransform _thisRectTrm;
    private bool _isClear;

    private float _lastStartTime;
    private Vector2 _startPos;

    public void RestartSet()
    {
        _lastStartTime = Time.time;
        _isClear = false;
    }

    private void Awake()
    {
        _thisRectTrm = GetComponent<RectTransform>();
        _startPos = _thisRectTrm.anchoredPosition;
    }

    private void Update()
    {
        Debug.Log(Mathf.Abs(Mathf.Abs(_thisRectTrm.anchoredPosition.x) - Mathf.Abs(_startPos.x)));
        Debug.Log(Mathf.Abs(_thisRectTrm.anchoredPosition.x) + "//" +  Mathf.Abs(_startPos.x));
        if (!_isClear && (Mathf.Abs(Mathf.Abs(target.anchoredPosition.y) - Mathf.Abs(_thisRectTrm.anchoredPosition.y)) > distance || Mathf.Abs(Mathf.Abs(_thisRectTrm.anchoredPosition.x) - Mathf.Abs(_startPos.x)) > distance))
        {
            transform.GetComponentInParent<Stage>().Clear();
            _isClear = true;
        }
        else if (!_isClear && _lastStartTime + 10 < Time.time)
        {
            transform.GetComponentInParent<Stage>().Clear();
            _isClear = true;
        }
    }
}
