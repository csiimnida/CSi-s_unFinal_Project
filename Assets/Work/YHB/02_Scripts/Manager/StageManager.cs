using Library;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoSingleton<StageManager>
{
    [SerializeField] private List<DifficultySO> difficulty = new List<DifficultySO>();
    [SerializeField] private string str;

    public Action OnGameClear;
    public Action<StageSO> OnStageChange;

    private NotOverlapValue<StageSO> _notOverlapStage;
    private int _curDifficultyIndex = 0;
    private int CurDifficultyIndex
    {
        get => _curDifficultyIndex;
        set
        {
            _curDifficultyIndex = Mathf.Clamp(value, 0, difficulty.Count - 1);
        }
    }

    private int _curStageIndex = 0;
    private int CurStageIndex
    {
        get => _curStageIndex;
        set => _curStageIndex = Mathf.Clamp(value, 0, difficulty[CurDifficultyIndex].stages.Count);
    }

    private List<StageSO> _curStageSOList;
    private List<Stage> _curStageList;
    private bool _gameClear;

    #region test
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StageClear();
        }
    }
    #endregion

    private void Awake()
    {
        if(difficulty is null) return;
        Initialize();
    }

    private void Initialize()
    {
        _gameClear = false;

        CurDifficultyIndex = 0;
        _notOverlapStage = new NotOverlapValue<StageSO>(difficulty[0].stages);

        _curStageList = new List<Stage>();
        _curStageSOList = new List<StageSO>();

        CurStageIndex = 0;
        InstantiateStage();
    }

    #region stage

    private void InstantiateStage()
    {
        _curStageList.Clear();
        _curStageSOList.Clear();

        for (int i = 0; i < _notOverlapStage.GetRangeCount(); i++)
        {
            _curStageSOList.Add(_notOverlapStage.GetValue());

            _curStageList.Add(
                new GameObjectBuilder(Instantiate(_curStageSOList[_curStageSOList.Count - 1].stagePrefab).gameObject)
                .SetParent(transform)
                .SetPosition(transform.position)
                .SetActive(false)
                .Build()
                .GetComponent<Stage>()
                );
        }

        _curStageList[0].gameObject.SetActive(true);
        _curStageList[0].Restart();
        OnStageChange?.Invoke(_curStageSOList[0]);
    }

    public void StageClear()
    {
        if (_gameClear) return;

        _curStageList[CurStageIndex++].gameObject.SetActive(false);

        if (CurStageIndex >= difficulty[CurDifficultyIndex].stages.Count)
        {
            NextDifficulty();
            return;
        }

        _curStageList[CurStageIndex].gameObject.SetActive(true);
        _curStageList[CurStageIndex].Restart();
        OnStageChange?.Invoke(_curStageSOList[CurStageIndex]);
    }

    public void NextDifficulty()
    {
        if (++CurDifficultyIndex >= difficulty.Count)
        {
            GameClear();
            return;
        }
        _notOverlapStage = new NotOverlapValue<StageSO>(difficulty[CurDifficultyIndex].stages);
        InstantiateStage();

        CurStageIndex = 0;
        _curStageList[0].gameObject.SetActive(true);
        _curStageList[CurStageIndex].Restart();
        OnStageChange?.Invoke(_curStageSOList[CurStageIndex]);
    }

    public void GameClear()
    {
        if (_gameClear) return;

        _curStageList[_curStageList.Count - 1].gameObject.SetActive(true);
        Time.timeScale = 0;
        _gameClear = true;
        OnGameClear?.Invoke();
        GameManager.Instance.ClearTime = UIManager.Instance.time;
        SceneManager.LoadScene(str);
    }

    #endregion

#if UNITY_EDITOR

    private void OnValidate()
    {
        difficulty.Sort(new GreaterComparer<DifficultySO>(s => s.number));
    }

#endif
}
