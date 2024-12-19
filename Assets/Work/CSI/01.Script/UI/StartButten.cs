using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButten : MonoBehaviour
{
    public void StartBt()
    {
        SceneManager.LoadScene("CSiMain");
    }

    public void SettingBt()
    {
        
    }

    public void QuitBt()
    {
        Application.Quit();
    }
}
