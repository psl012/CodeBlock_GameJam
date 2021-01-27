using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    [Range(1, 50)] public float jumpVelocity;
    [Range(1, 50)] public float fallMultiplier = 2.5f;
    [Range(1, 50)] public float lowJumpMultiplier = 2f;
    [Range(1, 50)] public float horizontalJumpMultiplier = 2f;

    LayerMask _groundLayerMask;
    BoxCollider2D _boxCollider2D;
    Rigidbody2D _rigidBody;
    bool _jumpRequest;

    public bool _isAutomateJump;

    private void Awake()
    {
        Initialization();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (_jumpRequest)
        {
            _jumpRequest = false;
            Vector2 jumpForce = new Vector2(horizontalJumpMultiplier, jumpVelocity);
            _rigidBody.AddForce(jumpForce, ForceMode2D.Impulse);
        }

        JumpGravity();
    }


    protected  void HandleInput()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            _jumpRequest = true;
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            _jumpRequest = true;
        }
    }

    private void JumpGravity()
    {
        if (_rigidBody.velocity.y < 0)
        {
            _rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        else if (_rigidBody.velocity.y > 0)
        {
            _rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, _boxCollider2D.bounds.extents.y + extraHeightText, _groundLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(_boxCollider2D.bounds.center + new Vector3(_boxCollider2D.bounds.extents.x, 0), Vector2.down * (_boxCollider2D.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(_boxCollider2D.bounds.center - new Vector3(_boxCollider2D.bounds.extents.x, 0), Vector2.down * (_boxCollider2D.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(_boxCollider2D.bounds.center - new Vector3(_boxCollider2D.bounds.extents.x, _boxCollider2D.bounds.extents.y + extraHeightText), Vector2.right * (_boxCollider2D.bounds.extents.x) * 2, rayColor);
        return raycastHit.collider != null;
    }

    protected  void Initialization()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundLayerMask = LayerMask.GetMask("Ground");
        _jumpRequest = false;        
    }

}
