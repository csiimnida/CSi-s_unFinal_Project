using System;
using UnityEngine;

public class BackendTest : MonoSingleton<BackendTest>
{
    private float _time;
    private bool _gameEnd = false;

    private void Awake()
    {
        if (_gameEnd) FinishGame(_time);
        else _gameEnd = false;
    }

    public void SetTime(float time)
    {
        _time = time;
        _gameEnd = true;
    }

    private void FinishGame(float Finishtime)
    {
        if (GameManager.Instance.UploadRank)
        {
            BackenRank.Instance.GetMyRanking();
            RealyRankUpload.Instance.gameObject.SetActive(true);
            RealyRankUpload.Instance.SetTiem(Finishtime);
        }
    }
}
