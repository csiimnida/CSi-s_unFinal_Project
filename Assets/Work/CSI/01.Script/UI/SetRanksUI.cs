using System;
using BackEnd;
using UnityEngine;

public class SetRanksUI : MonoSingleton<SetRanksUI>
{
    [SerializeField] private Transform Prefab;
    [SerializeField] private Transform Panal;


    public void Set(BackendReturnObject bro)
    {
        for (int i = 0; i < Panal.childCount; i++)
        {
            Destroy(Panal.GetChild(i).gameObject);
        }

        foreach (LitJson.JsonData jsonData in bro.FlattenRows())
        {
            string no = jsonData["rank"].ToString();
            string name = string.Empty;
            try
            {
                name = jsonData["nickname"].ToString();

            }
            catch
            {
                name = "NullError";

            }
            string time = jsonData["score"].ToString();

            Instantiate(Prefab, Panal).GetComponent<PanalData>().SetData(no, name, time);
            
        }
    }
}
