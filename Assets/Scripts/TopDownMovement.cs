using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    private TopDownCharacterController _controller;
    private Vector2 _movementDirection = Vector2.zero;
    private CharacterStatsHandler _stats;
    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _stats = GetComponent<CharacterStatsHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _stats.CurrentStates.speed;
        _rigidbody.velocity = direction;
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    
}
