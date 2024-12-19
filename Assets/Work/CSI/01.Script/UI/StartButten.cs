using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButten : MonoBehaviour
{
    public GameObject penal;
    public GameObject infopenal;
    public bool firstStart = false;
    public GameObject infotxt;
    public void StartBt()
    {
        infopenal.SetActive(true);
    }

    public void StartCheck()
    {
        SceneManager.LoadScene("InGame");
    }

    public void SettingBt()
    {
        penal.SetActive(true);
    }

    public void QuitBt()
    {
        Application.Quit();
    }
}
