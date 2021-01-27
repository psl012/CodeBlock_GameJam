using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float _bulletSpeed;
    public float _acceleration;
    public float _deathTimer;

    Rigidbody2D _rigidBody;
    protected Vector3 _movement;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _deathTimer);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        _movement = new Vector3(1, 0, 0)*_bulletSpeed*Time.deltaTime;
        _rigidBody.MovePosition(transform.position + _movement);

        _bulletSpeed += _acceleration * Time.deltaTime;
    }
}
