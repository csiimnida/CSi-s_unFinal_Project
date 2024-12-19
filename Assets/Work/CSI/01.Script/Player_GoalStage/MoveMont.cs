using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))] 
public class MoveMont : MonoBehaviour ,IRestartable
{
    [field:SerializeField]public InputReader _InputReader{get; private set;}
    [SerializeField]private Animator _animator;
    private Rigidbody2D _Rigidbody2D;
    private Vector2 move;
    [SerializeField] private float speed;
    [SerializeField] private float JumpPower;
    private Vector3 startPosition;

    private void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        try
        {
            _animator = GetComponentInChildren<Animator>();

        }
        catch
        {

        }
    }


    private void Start()
    {
        _InputReader.OnMoveEvent += HandleMoveEvent;
        _InputReader.OnJumpEvent += Jump;
    }
    private void HandleMoveEvent(Vector2 obj)
    {
        move = obj;
        if (_animator == null) return;
        if (Mathf.Abs(move.x) > 0)
        {
            
            _animator.Play("Move");
        }
        else
        {
            _animator.Play("Idle");
        }
    }
    private void Jump()
    {
        _Rigidbody2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
    }

    private void Update()
    {
        _Rigidbody2D.velocity = new Vector2((move.x * speed),_Rigidbody2D.velocity.y);

    }

    public void RestartSet()
    {
        transform.position = startPosition;
    }

    public void RestartEnd()
    {
        
    }
}
