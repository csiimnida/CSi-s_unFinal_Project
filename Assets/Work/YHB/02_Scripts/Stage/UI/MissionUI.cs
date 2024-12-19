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

    public void RestartSet()
    {
        _lastStartTime = Time.time;
        _isClear = false;
    }

    private void Awake()
    {
        _thisRectTrm = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (!_isClear && Mathf.Abs(Mathf.Abs(target.anchoredPosition.y) - Mathf.Abs(_thisRectTrm.anchoredPosition.y)) > distance)
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
