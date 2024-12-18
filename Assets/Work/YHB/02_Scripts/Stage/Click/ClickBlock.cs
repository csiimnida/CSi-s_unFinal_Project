using Library;
using System;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using Random = UnityEngine.Random;

public class ClickBlock : MonoBehaviour, IRestartable
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private float distance, blinkDistance;
    [SerializeField] private int maxMoveStack;
    [SerializeField] private bool canMoving, canBlink, canChange, isClearBtn;
    [SerializeField] private Transform changeTarget;

    private Rigidbody2D _rid;
    private Action _starMove;
    private int _moveStack;

    private Vector3 _startPos;

    public void RestartSet()
    {
        transform.position = _startPos;
        _rid.velocity = Vector3.zero;
        _moveStack = 0;

        inputReader.OnMousePosEvent += HandleCheckMouse;
        inputReader.OnMouseClickEvent += HandleClick;

        if (canMoving) _starMove += HandleDVDMove;
        if (canBlink) _starMove += HandleBlink;
        if (canChange) _starMove += HandleChange;

        Debug.Log("ss");
    }

    public void RestartEnd()
    {
        inputReader.OnMousePosEvent -= HandleCheckMouse;
        inputReader.OnMouseClickEvent -= HandleClick;

        if (canMoving) _starMove -= HandleDVDMove;
        if (canBlink) _starMove -= HandleBlink;
        if (canChange) _starMove -= HandleChange;
    }

    private void Awake()
    {
        _startPos = transform.position;

        _rid = transform.TryAddComponent<Rigidbody2D>();
        _rid.gravityScale = 0;

        Debug.Log("set");
    }

    private void HandleDVDMove()
    {
        int x;
        do
        {
            x = Random.Range(-1, 2);
        } while (x == 0);
        int y;
        do
        {
            y = Random.Range(-1, 2);
        } while (y == 0);
        _rid.velocity = new Vector3(x, y) * 5;
    }

    private void HandleBlink()
    {
        int x;
        do
        {
            x = Random.Range(-1, 2);
        } while (x == 0);

        transform.position += new Vector3(x * blinkDistance, Random.Range(-1, 2) * blinkDistance);
    }

    private void HandleChange()
    {
        Vector2 pos = changeTarget.position;
        changeTarget.position = transform.position;
        transform.position = pos;
    }

    private void HandleCheckMouse(Vector2 pos)
    {
        if (_moveStack >= maxMoveStack) return;

        if ((pos - (Vector2)transform.position).magnitude < distance)
        {
            _moveStack++;
            _starMove?.Invoke();
        }
    }

    private void HandleClick(Vector2 pos)
    {
        if (isClearBtn && (pos - (Vector2)transform.position).magnitude < distance)
        {
            transform.GetComponentInParent<Stage>().Clear();
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
    }

    private void OnValidate()
    {
        if (!canChange) changeTarget = null;
        if (!canBlink) blinkDistance = 0;
        if (!(canChange || canBlink || canMoving)) maxMoveStack = 0;
    }
#endif
}
