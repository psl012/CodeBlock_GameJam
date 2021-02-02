using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAround : MonoBehaviour
{
    public DragAroundTarget correctForm;
    public bool isCorrectPosition { get; set; } = false;


    float _startPosX;
    float _startPosY;
    Collider2D _collider2D;

    bool _isMoving = false;
    Rigidbody2D _rigidBody;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
      //  Debug.Log(correctForm.name);
    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log(correctForm.transform.position);
        if (_isMoving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = new Vector3(mousePos.x - _startPosX, mousePos.y - _startPosY, transform.localPosition.z);
        }

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            _startPosX = mousePos.x - transform.position.x;
            _startPosY = mousePos.y - transform.position.y;

            _isMoving = true;

            if (_collider2D != null) _collider2D.enabled = false;
        }
    }

    private void OnMouseUp()
    {
        _isMoving = false;

        if (_collider2D != null) _collider2D.enabled = true;
        if (correctForm != null)
        {
            CheckCorrectPosition();
        }

    }

    private void CheckCorrectPosition()
    {
        if (Mathf.Abs(transform.position.x - correctForm.transform.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - correctForm.transform.position.y) <= 0.5f)
        {
            transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            isCorrectPosition = true;
            _rigidBody.velocity = Vector2.zero;
            _rigidBody.isKinematic = true;
            correctForm.isObjectInCorrectPosition = true;
        }
        else
        {
            _rigidBody.isKinematic = false;
            correctForm.isObjectInCorrectPosition = false;
        }
    }
}
