using System;
using UnityEngine;

public class BackendTest : MonoBehaviour
{
    private Login login;
    private SignUp signUp;
    private BackenRank backenRank;
    private ResetBackend _resetBackend;

    [SerializeField]
    private RealyRankUpload _realyRankUpload;

    private void Awake()
    {
        login = GetComponentInChildren<Login>();
        signUp = GetComponentInChildren<SignUp>();
        backenRank = GetComponentInChildren<BackenRank>();
        _resetBackend = GetComponentInChildren<ResetBackend>();
    }

    private void FinishGame(float Finishtime)
    {
        if (GameManager.Instance.UploadRank)
        {
            BackenRank.Instance.GetMyRanking();
            _realyRankUpload.gameObject.SetActive(true);
            _realyRankUpload.SetTiem(Finishtime);
        }
    }


}
