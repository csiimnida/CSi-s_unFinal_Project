using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoSingleton<GameManager>
{
    public void SuccessGame()
    {
        Debug.Log("SuccessGame");
    }
}
