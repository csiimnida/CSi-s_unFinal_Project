using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeTime = 1, cameraSize = 5;
    [SerializeField] private bool cursor;

    public Action OnClearEvent { get; private set; }
    public Action OnGameEndEvent { get; private set; }

    private IRestartable[] _restarters;

    protected void OnEnable()
    {
        Camera.main.transform.position = new Vector3(0, 0, -10);
        Camera.main.orthographicSize = cameraSize;

        Cursor.visible = cursor;

        OnClearEvent += StageManager.Instance.StageClear;
        OnGameEndEvent += Restart;
        _restarters = transform.GetComponentsInChildren<IRestartable>();
    }

    protected void OnDisable()
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
        fadeImage.transform.parent.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        fadeImage.DOFade(1f, 0).SetDelay(0.1f).OnComplete(() =>
        {
            Cursor.lockState = CursorLockMode.None;
            fadeImage.DOFade(0f, fadeTime).OnComplete(() =>
            {
                fadeImage.transform.parent.gameObject.SetActive(false);
            });
        });
        foreach (IRestartable item in _restarters)
        {
            item.RestartSet();
        }
    }
}
