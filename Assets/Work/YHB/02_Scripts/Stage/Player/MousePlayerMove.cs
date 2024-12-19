using Library;
using System.Collections.Generic;
using UnityEngine;

public class MousePlayerMove : MonoBehaviour
{
    [SerializeField] private InputReader inputReadeer;
    [SerializeField] private LayerMask layer;

    private Rigidbody2D _rid;
    private Vector3 _startPos;
    private float _gravity;
    private bool _dragging;

    private void Start()
    {
        _startPos = transform.position;
        _rid = transform.TryAddComponent<Rigidbody2D>();
        _gravity = _rid.gravityScale;

        inputReadeer.OnMouseClickEvent += OnBeginDrag;
        inputReadeer.OnMousePosEvent += OnDrag;
        inputReadeer.OnMouseClickCancelEvent += OnEndDrag;
    }

    private void OnDisable()
    {
        inputReadeer.OnMouseClickEvent -= OnBeginDrag;
        inputReadeer.OnMousePosEvent -= OnDrag;
        inputReadeer.OnMouseClickCancelEvent -= OnEndDrag;
    }

    public void RestartSet()
    {
        transform.position = _startPos;
        _dragging = false;
    }

    public void OnDrag(Vector2 eventData)
    {
        if (!_dragging) return;

        Vector3 mousePos = eventData;
        mousePos.z = transform.position.z;
        transform.position = mousePos;
    }

    public void OnBeginDrag(Vector2 eventData)
    {
        Collider2D c = Physics2D.OverlapCircle(eventData, 0.1f, layer);
        if (c is null) return;
        if (_dragging || !EqualityComparer<Transform>.Default.Equals(c.transform, transform)) return;

        _dragging = true;
        Vector3 mousePos = eventData;
        mousePos.z = transform.position.z;
        transform.position = mousePos;
        _rid.gravityScale = 0;
    }

    public void OnEndDrag(Vector2 eventData)
    {
        _dragging = false;

        _rid.gravityScale = _gravity;
    }
}
