using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class Login : MonoBehaviour
{
    public void CustomLogin(string id, string pw,string nickname = "Test")
    {
        Debug.Log("로그인을 요청합니다.");
    
        var bro = Backend.BMember.CustomLogin(id, pw);
    
        if (bro.IsSuccess())
        {
            Backend.BMember.CreateNickname(nickname);
            Debug.Log("로그인이 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("로그인이 실패했습니다. : " + bro);
        }
    }
}
