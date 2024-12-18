using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanalData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI No;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Time;

    public void SetData<T, Y>(T no, Y name, float time)
    {
        No.SetText(no.ToString());
        Name.SetText(name.ToString());
        Time.SetText((Mathf.Round(time * 1000) / 1000) + "초");
}
}
