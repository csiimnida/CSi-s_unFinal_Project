using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private bool isGameOverStage;

    public Action OnClearEvent { get; private set; }
    public Action OnGameEndEvent { get; private set; }

    private IRestartable[] _restarters;

    private void OnEnable()
    {
        // OnClearEvent += GameManager.Instance.StageClear;
        // OnGameEndEvent += GameManager.Instance.IsGame && isGameOverStage ? GameManager.Instance.GameOver : Restart;
        _restarters = transform.GetComponentsInChildren<IRestartable>();
    }

    private void OnDisable()
    {
        // OnClearEvent -= GameManager.Instance.StageClear;
        // OnGameEndEvent -= GameManager.Instance.IsGame && isGameOverStage ? GameManager.Instance.GameOver : Restart;
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
