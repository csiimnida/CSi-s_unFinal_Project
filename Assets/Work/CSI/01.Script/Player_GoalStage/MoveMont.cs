using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))] 
public class MoveMont : MonoBehaviour
{
    [field:SerializeField]public InputReader _InputReader{get; private set;}
    private Rigidbody2D _Rigidbody2D;
    private Vector2 move;
    [SerializeField] private float speed;
    [SerializeField] private float JumpPower;

    private void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        _InputReader.OnMoveEvent += vector2 => move = vector2;
        _InputReader.OnJumpEvent += Jump;
    }

    private void Jump()
    {
        _Rigidbody2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
    }

    private void Update()
    {
        _Rigidbody2D.velocity = new Vector2((move.x * speed),_Rigidbody2D.velocity.y);
    }
}
