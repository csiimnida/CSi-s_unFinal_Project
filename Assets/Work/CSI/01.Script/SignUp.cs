using System;
using System.Collections;
using System.Collections.Generic;
using BackEnd;
using UnityEngine;

public class SignUp : MonoBehaviour
{
    public static SignUp Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
            /*
            회원가입에 실패했습니다. : StatusCode : 409
            ErrorCode : DuplicatedParameterException
            Message : Duplicated customId, 중복된 customId 입니다
            */
            Debug.LogError("회원가입에 실패했습니다. : " + bro);
            if (bro.ErrorCode == "DuplicatedParameterException")
            {
                Debug.LogWarning("이미 존재하는 ID 입니다.");
                return;
            }
        }
    }
}
