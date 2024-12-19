using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxFall : MonoBehaviour, IRestartable
{
    private Rigidbody2D _rigidbody2D;
    private Vector3 _position;
    
    public void RestartEnd()
    {
    }

    public void RestartSet()
    {
        transform.position = _position;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;

    }

    private void Awake()
    {
        _position = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
