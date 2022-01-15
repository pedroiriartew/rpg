using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private float _fallMultiplier = 2.5f;
    private float _lowJumpMultiplier = 2.0f;

    private Rigidbody2D _rbReference;

    private void Awake()
    {
        _rbReference = GetComponent<Rigidbody2D>();
    }

    private void Update()//repasar
    {
        if (_rbReference.velocity.y <= 0)
        {
            _rbReference.velocity += Vector2.up * Physics.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rbReference.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rbReference.velocity += Vector2.up * Physics.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

}

