using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIStage : MonoBehaviour
{
    [SerializeField] private bool offBack, offTimer, offMisiion;

    private List<RectTransform> _offUI;

    private void OnEnable()
    {
        _offUI = new List<RectTransform>();

        _offUI.Clear();

        if (offBack) _offUI.Add(UIManager.Instance.GetBackBtnTrm());
        if (offTimer) _offUI.Add(UIManager.Instance.GetTimerTrm());
        if (offMisiion) _offUI.Add(UIManager.Instance.GetMisiionTrm());

        foreach (RectTransform item in _offUI)
        {
            item.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        foreach (RectTransform item in _offUI)
        {
            item.gameObject.SetActive(true);
        }
    }

    public void BackClick()
    {
        transform.GetComponent<Stage>().Clear();
    }
}
