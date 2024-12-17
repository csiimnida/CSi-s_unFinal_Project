using System;
using UnityEngine;
using BackEnd;
using UnityEditor.PackageManager;
using ErrorCode = BackEnd.Tcp.ErrorCode;

public class Login : MonoBehaviour
{
    public void CustomLogin(string id, string pw,string nickname = "Test")
    {
    
        var bro = Backend.BMember.CustomLogin(id, pw);
    
        if (bro.IsSuccess())
        {
            ChengeNickname(nickname);
            Debug.Log("로그인이 성공했습니다. : " + bro);
        }
        else
        {
            if (bro.ErrorCode == "BadUnauthorizedException")
            {
                Debug.LogError("로그인이 실패했습니다. \n 계정이 없습니다. 계정을 생성합니다.");
                SignUp.Instance.CustomSignUp(id, pw);
                return;
            }
            Debug.LogError("로그인이 실패했습니다. : " + bro);
            /*로그인이 실패했습니다. : StatusCode : 401
            ErrorCode : BadUnauthorizedException
            Message : bad customId, 잘못된 customId 입니다
            */
        }
    }
    public void Start()
    {
        string uniqueId = GetUniqueComputerId();
        Debug.Log("Unique ID: " + uniqueId);
    }

    public string GetUniqueComputerId()
    {
        string uniqueId = string.Empty;
        uniqueId = SystemInfo.deviceUniqueIdentifier;

        return uniqueId;
    }

    public void ChengeNickname(string Nicname)
    {
        Backend.BMember.CreateNickname(Nicname, (callback) =>
        {
            if (callback.IsSuccess())
            {
                Debug.Log("닉네임 변경 성공!");
            }
            else
            {
                Debug.LogError("닉네임 변경 실패");
                switch (callback.StatusCode)
                {
                    case 400:
                        Debug.LogWarning("닉네임이 20자 이상입니다. 또는 닉네임에 앞/뒤 공백이 있습니다.");
                        break;
                    case 409:
                        Debug.LogWarning("누군가가 이미 사용중인 닉네임 입니다.");
                        break;
                }
            }
        });

    }
}
