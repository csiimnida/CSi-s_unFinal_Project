using System;
using UnityEngine;

public class BackendTest : MonoBehaviour
{
    private void Start()
    {
        FinishGame(GameManager.Instance.ClearTime);
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
