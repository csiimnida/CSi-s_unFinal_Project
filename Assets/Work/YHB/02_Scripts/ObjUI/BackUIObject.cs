using Library;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackUIObject : MonoBehaviour
{
    private Rigidbody2D _rid;
    private Collider2D _collider;

    private void Awake()
    {
        _rid = transform.TryAddComponent<Rigidbody2D>();
        _collider = transform.TryAddComponent<Collider2D, CircleCollider2D>();
    }
}
