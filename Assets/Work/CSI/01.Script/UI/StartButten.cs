using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButten : MonoBehaviour
{
    public GameObject penal;
    public void StartBt()
    {
        SceneManager.LoadScene("CSiMain");
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
