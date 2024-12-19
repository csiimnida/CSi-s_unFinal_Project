using Library;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoSingleton<StageManager>
{
    [SerializeField] private List<DifficultySO> difficulty = new List<DifficultySO>();

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
        if(difficulty == null) return;
        Initialize();
    }

    private void Initialize()
    {
        _gameClear = false;

        CurDifficultyIndex = 0;
        _notOverlapStage = new NotOverlapValue<StageSO>(difficulty[0].stages);

        _curStageList = new List<Stage>();

        CurStageIndex = 0;
        InstantiateStage();
    }

    #region stage

    private void InstantiateStage()
    {
        _curStageList.Clear();

        for (int i = 0; i < _notOverlapStage.GetRangeCount(); i++)
        {
            _curStageList.Add(
                new GameObjectBuilder(Instantiate(_notOverlapStage.GetValue().stagePrefab).gameObject)
                .SetParent(transform)
                .SetPosition(transform.position)
                .SetActive(false)
                .Build()
                .GetComponent<Stage>()
                );
        }

        _curStageList[0].gameObject.SetActive(true);
        _curStageList[0].Restart();
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
    }

    public void GameClear()
    {
        if (_gameClear) return;

        _curStageList[_curStageList.Count - 1].gameObject.SetActive(true);
        Time.timeScale = 0;
        _gameClear = true;
        Debug.Log("GameClear");
    }

    #endregion

#if UNITY_EDITOR

    private void OnValidate()
    {
        difficulty.Sort(new GreaterComparer<DifficultySO>(s => s.number));
    }

#endif
}
