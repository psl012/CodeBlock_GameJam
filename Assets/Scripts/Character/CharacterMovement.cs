using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float _moveSpeed;
    Rigidbody2D _rigidBody2D;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveRight()
    {
        Vector2 move = new Vector2(1,0);
        transform.Translate(move * _moveSpeed * Time.deltaTime);
    }
}
