using UnityEngine;

public class MoveMission : MonoBehaviour, IRestartable
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform target;
    [SerializeField] private float speed, distance;

    private RectTransform _rect;
    private Camera _mainCam;
    private Vector2 _screenBounds, _pos, _startPos;
    private bool _isClear;

    public void RestartSet()
    {
        _rect.anchoredPosition = _startPos;
    }

    private void Awake()
    {
        _isClear = false;
        _mainCam = Camera.main;

        float h = _mainCam.orthographicSize;

        _screenBounds = _mainCam.WorldToScreenPoint(new Vector2(h * _mainCam.aspect - 1, h - 1));

        _rect = GetComponent<RectTransform>();
        _startPos = _rect.anchoredPosition;
    }

    private void Update()
    {
        _pos = _mainCam.WorldToScreenPoint(_mainCam.ScreenToWorldPoint(_rect.anchoredPosition) + ((Vector3)inputReader.InputVector.normalized * speed * Time.deltaTime));

        _pos.x = Mathf.Clamp(_pos.x, -_screenBounds.x, 0);
        _pos.y = Mathf.Clamp(_pos.y, -_screenBounds.y, 0);

        _rect.anchoredPosition = _pos;
        _pos = _rect.anchoredPosition;

        if (!_isClear && Vector2.Distance((Vector2)target.position, (Vector2)_mainCam.ScreenToWorldPoint(_rect.anchoredPosition)) < 36.2f && Vector2.Distance((Vector2)target.position, (Vector2)_mainCam.ScreenToWorldPoint(_rect.anchoredPosition)) > 34.5f)
        {
            transform.GetComponentInParent<Stage>().Clear();
            _isClear = true;
        }
    }
}
