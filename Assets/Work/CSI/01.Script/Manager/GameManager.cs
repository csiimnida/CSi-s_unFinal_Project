using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoSingleton<GameManager>
{
    public string PlayerName;
    public bool UploadRank;
    public float RankTime;
    public void SuccessGame()
    {
        Debug.Log("SuccessGame");
    }
}
