using System.Collections;
using System.Collections.Generic;
using System.Text;
using BackEnd;
using UnityEngine;

public class BackenRank : MonoBehaviour
{
    public void RankInsert(float score)
    {
        string rankUUID = "0193cfe2-1c02-7219-b050-22f02d8fe0bf"; 
    
        string tableName = "Rank";
        string rowInDate = string.Empty;
    

        Debug.Log("데이터 조회를 시도합니다.");
        var bro = Backend.GameData.GetMyData(tableName, new Where());
    
        if (bro.IsSuccess() == false)
        {
            Debug.LogError("데이터 조회 중 문제가 발생했습니다 : " + bro);
            return;
        }
    
        Debug.Log("데이터 조회에 성공했습니다 : " + bro);
    
        if (bro.FlattenRows().Count > 0)
        {
            rowInDate = bro.FlattenRows()[0]["inDate"].ToString();
        }
        else
        {
            Debug.Log("데이터가 존재하지 않습니다. 데이터 삽입을 시도합니다.");
            var bro2 = Backend.GameData.Insert(tableName);
    
            if (bro2.IsSuccess() == false)
            {
                Debug.LogError("데이터 삽입 중 문제가 발생했습니다 : " + bro2);
                return;
            }
    
            Debug.Log("데이터 삽입에 성공했습니다 : " + bro2);
    
            rowInDate = bro2.GetInDate();
        }
    
        Debug.Log("내 게임 정보의 rowInDate : " + rowInDate); 
    
        Param param = new Param();
        param.Add("Time", score);
    
        // 추출된 rowIndate를 가진 데이터에 param값으로 수정을 진행하고 랭킹에 데이터를 업데이트합니다.  
        Debug.Log("랭킹 삽입을 시도합니다.");
        var rankBro = Backend.URank.User.UpdateUserScore(rankUUID, tableName, rowInDate, param);
    
        if (rankBro.IsSuccess() == false)
        {
            Debug.LogError("랭킹 등록 중 오류가 발생했습니다. : " + rankBro);
            return;
        }
    
        Debug.Log("랭킹 삽입에 성공했습니다. : " + rankBro);
    }
    
    public void RankGet()
    {
        string rankUUID = "0193cfe2-1c02-7219-b050-22f02d8fe0bf";
        var bro = Backend.URank.User.GetRankList(rankUUID);

        if (bro.IsSuccess() == false)
        {
            Debug.LogError("랭킹 조회중 오류가 발생했습니다. : " + bro);
            return;
        }

        Debug.Log("랭킹 조회에 성공했습니다. : " + bro);

        Debug.Log("총 랭킹 등록 유저 수 : " + bro.GetFlattenJSON()["totalCount"].ToString());

        foreach (LitJson.JsonData jsonData in bro.FlattenRows())
        {
            Debug.Log(jsonData);
            StringBuilder info = new StringBuilder();

            info.AppendLine("순위 : " + jsonData["rank"].ToString());
            info.AppendLine("닉네임 : " + jsonData["nickname"].ToString());
            info.AppendLine("시간 : " + jsonData["score"].ToString());
            info.AppendLine("gamerInDate : " + jsonData["gamerInDate"].ToString());
            info.AppendLine("정렬번호 : " + jsonData["index"].ToString());
            info.AppendLine();
            Debug.Log(info);
        }
    }
}
