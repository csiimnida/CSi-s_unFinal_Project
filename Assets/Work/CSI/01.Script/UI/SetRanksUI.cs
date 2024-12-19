using System;
using BackEnd;
using DG.Tweening;
using UnityEngine;

public class SetRanksUI : MonoSingleton<SetRanksUI>
{
    [SerializeField] private Transform Prefab;
    [SerializeField] private Transform Panal;
    [SerializeField] private PanalData MyRank;
    [SerializeField] private bool first = true;

    private void Start()
    {
        if(first == true)
        {
            transform.GetComponent<RectTransform>().DOAnchorPosX(-572, 0.4f).SetEase(Ease.Unset);
        }
    }



    public void Set(BackendReturnObject bro)
    {
        for (int i = 0; i < Panal.childCount; i++)
        {
            Destroy(Panal.GetChild(i).gameObject);
        }

        var manager = GameManager.Instance;
        MyRank.SetData(manager.No,manager.Name,manager.Time);
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

            float time = float.Parse(jsonData["score"].ToString());

            Instantiate(Prefab, Panal).GetComponent<PanalData>().SetData(no, name, time);
            
        }
    }

}
