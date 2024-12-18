using System;
using BackEnd;
using UnityEngine;

public class SetRanksUI : MonoSingleton<SetRanksUI>
{
    [SerializeField] private Transform Prefab;
    [SerializeField] private Transform Panal;
    [SerializeField] private PanalData MyRank;


    public void Set(BackendReturnObject bro)
    {
        for (int i = 0; i < Panal.childCount; i++)
        {
            Destroy(Panal.GetChild(i).gameObject);
        }

        GetMyRanking();
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

    private void GetMyRanking()
    {
        BackendReturnObject data = Backend.URank.User.GetMyRank("0193cfe2-1c02-7219-b050-22f02d8fe0bf");
        if (!data.IsSuccess())
        {
            Debug.LogError("자신의 랭킹 불러오기 시패 : " + data);
            return;
        }
        foreach (LitJson.JsonData jsonData in data.FlattenRows())
        {
            MyRank.SetData(jsonData["rank"].ToString(),jsonData["nickname"].ToString(),jsonData["score"].ToString());
        }
    }
}
