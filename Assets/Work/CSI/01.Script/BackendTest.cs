using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackendTest : MonoBehaviour
{
    private Login login;
    private SignUp signUp;
    private BackenRank backenRank;

    private void Awake()
    {
        login = GetComponentInChildren<Login>();
        signUp = GetComponentInChildren<SignUp>();
        backenRank = GetComponentInChildren<BackenRank>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            login.CustomLogin(login.GetUniqueComputerId(),"123");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            signUp.CustomSignUp(login.GetUniqueComputerId(),"123");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            backenRank.RankInsert(10);
            backenRank.RankGet();
        }
    }
}
