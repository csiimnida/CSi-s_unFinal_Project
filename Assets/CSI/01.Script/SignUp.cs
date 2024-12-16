using System.Collections;
using System.Collections.Generic;
using BackEnd;
using UnityEngine;

public class SignUp : MonoBehaviour
{
    public void CustomSignUp(string id, string pw)
    {
        Debug.Log("회원가입을 요청합니다.");
    
        var bro = Backend.BMember.CustomSignUp(id, pw);
    
        if (bro.IsSuccess())
        {
            Debug.Log("회원가입에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("회원가입에 실패했습니다. : " + bro);
        }
    }
}
