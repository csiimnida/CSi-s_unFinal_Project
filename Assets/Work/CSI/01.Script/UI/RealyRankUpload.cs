using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BackEnd;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RealyRankUpload : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _NowTimeText;
    [SerializeField] private TextMeshProUGUI _RankTimeText;
    [SerializeField] private TMP_InputField _NameInputFild;
    [SerializeField] private Button _NameChangeButton;
    [SerializeField] private Button _uploadButton;
    [SerializeField] private RectTransform _NewPanelTrm;
    
    private TextMeshProUGUI _NameChangeButtonText;
    private float Nowtime;
    private bool Update;
    private bool NameChangeing;
    public void SetTiem(float time)
    {
        Nowtime = time;
        _NowTimeText.SetText(time.ToString() + "초");
        _RankTimeText.SetText(GameManager.Instance.Time.ToString() + "초");
        if (time < GameManager.Instance.Time)
        {
            _NewPanelTrm.gameObject.SetActive(true);
            _uploadButton.GetComponentInChildren<TextMeshProUGUI>().SetText("등록");
            Update = true;
        }
        else
        {
            Update = false;
            _uploadButton.GetComponentInChildren<TextMeshProUGUI>().SetText("확인");
        }
    }

    private void OnEnable()
    {
        _NewPanelTrm.gameObject.SetActive(false);
        _NameInputFild.text = GameManager.Instance.PlayerName;
    }

    private void Start()
    {
        _NameChangeButtonText = _NameInputFild.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>();
        _NameChangeButton.onClick.AddListener(HandleNameChange);
        _uploadButton.onClick.AddListener(HandleUploadRanking);
    }

    private void HandleUploadRanking()
    {
        if(NameChangeing) return;
        if (Update)
        {
            BackenRank.Instance.RankInsert(Nowtime);
        }
        
        gameObject.SetActive(false);
    }

    private string name_Save;
    private void HandleNameChange()
    {
        if (_NameInputFild.interactable)
        {
            Debug.Log(_NameInputFild.text);
            Debug.Log(_NameInputFild.text.Length);
            //이름 변경
            if (_NameInputFild.text == "")
            {
                _NameInputFild.placeholder.GetComponent<TextMeshProUGUI>().text = "닉네임이 있어야 합니다."; 
                return;
            }

            if (_NameInputFild.text.Length < 2)
            {
                _NameInputFild.text = "";
                _NameInputFild.placeholder.GetComponent<TextMeshProUGUI>().text = "닉네임이 2자 이상이어야 합니다."; 
                return;
            } 
            if (_NameInputFild.text.Length > 19)
            {
                _NameInputFild.text = "";
                _NameInputFild.placeholder.GetComponent<TextMeshProUGUI>().text = "닉네임이 20자 이하여야 합니다."; 
                return;
            }

            if (_NameInputFild.text[0] == ' ' || _NameInputFild.text[_NameInputFild.text.Length-1] == ' ')
            {
                _NameInputFild.text = "";
                _NameInputFild.placeholder.GetComponent<TextMeshProUGUI>().text = "닉네임에 앞/뒤 공백이 없어야 합니다."; 
                return;
            }
            

            if (_NameInputFild.text == GameManager.Instance.PlayerName)
            {
                _NameInputFild.interactable = false;
                _NameChangeButtonText.text = "변경";
                NameChangeing = false;
                return;
            }
            NameChangeing = false;
            
            Login.Instance.ChengeNickname(_NameInputFild.text);
            _NameInputFild.interactable = false;
            _NameChangeButtonText.text = "변경";
            
        }
        else
        {
            NameChangeing = true;
            _NameInputFild.interactable = true;
            _NameChangeButtonText.text = "적용";
            
        }
    }
}
