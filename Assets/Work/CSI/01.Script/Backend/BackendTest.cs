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

    private void Start()
    {
        if (true)//GameManager.Instance.UploadRank)
        {
            _realyRankUpload.gameObject.SetActive(true);
            _realyRankUpload.SetTiem(Time.deltaTime);
        }
    }

    public void UploadRank()
    {
        if (true) // 나중에 수정
        {
            login.CustomLogin();
        }
        backenRank.RankInsert(Time.deltaTime);
    }
}
