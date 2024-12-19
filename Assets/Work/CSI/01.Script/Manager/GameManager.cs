using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoSingleton<GameManager>
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    [Header("서버 데이터")] 
    public string PlayerName;
    public bool UploadRank;
    public bool Wifi;
    public float ClearTime;
    
    [Header("자신의 랭킹 정보")]
    public int No;
    public string Name;
    public float Time;

    public void SetUploadRank(bool value)
    {
        UploadRank = value;
    }

    public void SetRank(string rank , string name, string time)
    {
        int no = int.Parse(rank);
        No = no;
        Name = name;
        Time = float.Parse(time);
    }
}
