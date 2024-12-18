using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanalData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI No;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Time;

    public void SetData<T,Y,U>(T no, Y name, U time)
    {
        No.SetText(no.ToString());
        Name.SetText(name.ToString());
        Time.SetText(time.ToString());
    }
}
