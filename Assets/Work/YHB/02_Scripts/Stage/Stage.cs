using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Action OnClearEvent { get; private set; }
    public Action OnGameEndEvent { get; private set; }

    private IRestartable[] _restarters;

    private void OnEnable()
    {
        OnClearEvent += StageManager.Instance.StageClear;
        OnGameEndEvent += Restart;
        _restarters = transform.GetComponentsInChildren<IRestartable>();
    }

    private void OnDisable()
    {
        OnClearEvent -= StageManager.Instance.StageClear;
        OnGameEndEvent -= Restart;
    }

    public void Clear()
    {
        OnClearEvent?.Invoke();
    }

    public void GameEnd()
    {
        OnGameEndEvent?.Invoke();
    }

    public void Restart()
    {
        foreach (IRestartable item in _restarters)
        {
            item.RestartSet();
        }
    }
}
