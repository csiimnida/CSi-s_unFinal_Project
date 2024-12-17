using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanalData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI No;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Time;

    public void SetData(string no, string name, string time)
    {
        No.SetText(no);
        Name.SetText(name);
        Time.SetText(time);
    }
}
