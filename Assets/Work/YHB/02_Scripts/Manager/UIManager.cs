using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private TextMeshProUGUI mission;
    [SerializeField] private RectTransform backBtn;

    public float Time {  get; private set; }
    private bool _isGameClear;

    private void Awake()
    {
        _isGameClear = false;
        StageManager.Instance.OnGameClear += GameClear;
        StageManager.Instance.OnStageChange += StageClear;
    }

    private void GameClear()
    {
        _isGameClear = true;
        StageManager.Instance.OnGameClear -= GameClear;
        StageManager.Instance.OnStageChange -= StageClear;
    }

    private void StageClear(StageSO stage)
    {
        mission.text = stage.mission;
    }

    private void Update()
    {
        if (_isGameClear) return;

        ChangeTimer(Time += UnityEngine.Time.deltaTime);
    }

    private void ChangeTimer(float time)
    {
        timer.text = (Mathf.Round(time * 1000) / 1000).ToString();
    }

    public void HandleBackButtonClick(string sceneName)
    {
        if (!_isGameClear)
        {
            StageManager.Instance.OnGameClear -= GameClear;
            StageManager.Instance.OnStageChange -= StageClear;
        }

        SceneManager.LoadScene(sceneName);
    }

    private void OnDisable()
    {
        if (_isGameClear) return;

        StageManager.Instance.OnGameClear -= GameClear;
        StageManager.Instance.OnStageChange -= StageClear;
    }

    public RectTransform GetTimerTrm()
        => timer.rectTransform;

    public RectTransform GetMisiionTrm()
        => mission.rectTransform;

    public RectTransform GetBackBtnTrm()
        => backBtn;
}
