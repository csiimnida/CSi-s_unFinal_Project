using System;
using UnityEngine;
using BackEnd;


public class ResetBackend : MonoBehaviour
{
    private void Awake()
    {
        ResetBackendSystem();
    }

    private void Start()
    {
        BackenRank.Instance.RankGet();
    }

    public bool ResetBackendSystem()
    {
        var bro = Backend.Initialize(); // 뒤끝 초기화
        
        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success\
            Login.Instance.CustomLogin();
            return true;
        }
        else
        {
            /*초기화 실패 : StatusCode : 0
            ErrorCode : ConnectionError
            Message : Cannot connect to destination host
            */
            if (bro.StatusCode == 0)
            {
                Debug.LogError("인터냇을 확인 해주세요! \n Cannot connect to destination host");
            }
            Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생
            return false;
        }
    }
    
}
