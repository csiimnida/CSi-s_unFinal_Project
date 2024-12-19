using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeTime = 1;

    public Action OnClearEvent { get; private set; }
    public Action OnGameEndEvent { get; private set; }

    private IRestartable[] _restarters;

    protected void OnEnable()
    {
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
        //Cursor.WarpCursorPosition();

        fadeImage.transform.parent.gameObject.SetActive(true);
        fadeImage.DOFade(1f, 0).OnComplete(() => fadeImage.DOFade(0f, fadeTime).OnComplete(() => fadeImage.transform.parent.gameObject.SetActive(false)));
        foreach (IRestartable item in _restarters)
        {
            item.RestartSet();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }
}
