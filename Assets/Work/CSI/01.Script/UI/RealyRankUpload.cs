using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    
    private TextMeshProUGUI _NameChangeButtonText;
    
    public void SetTiem<T>(T time)
    {
        _RankTimeText.SetText(GameManager.Instance.RankTime.ToString() + "초");
        _NowTimeText.SetText(time.ToString() + "초");
    }

    private void OnEnable()
    {
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
        BackenRank.Instance.RankInsert(float.Parse(_NowTimeText.text));
        gameObject.SetActive(false);
    }

    private void HandleNameChange()
    {
        if (_NameInputFild.interactable)
        {
            //이름 변경
            Login.Instance.ChengeNickname(_NameInputFild.text);
            _NameInputFild.interactable = false;
            _NameChangeButtonText.text = "변경";
        }
        else
        {
            _NameInputFild.interactable = true;
            _NameChangeButtonText.text = "적용";
        }
    }
}
