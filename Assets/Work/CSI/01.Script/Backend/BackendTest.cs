using UnityEngine;

public class BackendTest : MonoBehaviour
{
    private Login login;
    private SignUp signUp;
    private BackenRank backenRank;
    private ResetBackend _resetBackend;

    private void Awake()
    {
        login = GetComponentInChildren<Login>();
        signUp = GetComponentInChildren<SignUp>();
        backenRank = GetComponentInChildren<BackenRank>();
        _resetBackend = GetComponentInChildren<ResetBackend>();
    }

    public void UploadRank()
    {
        if (true) // 나중에 수정
        {
            if (!_resetBackend.ResetBackendSystem())
            {
                Debug.LogError("서버 초기화 실패");
                return;
            }
            login.CustomLogin();
        }
        backenRank.RankInsert(Time.deltaTime);
    }
}
