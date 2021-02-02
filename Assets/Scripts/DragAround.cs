using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAround : MonoBehaviour
{
    public GameObject correctForm;

    float _startPosX;
    float _startPosY;
    Collider2D _collider2D;

    bool _isMoving = false;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
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

            transform.localPosition = new Vector3(mousePos.x - _startPosX, mousePos.y - _startPosY, transform.localPosition.z);
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
            if (Mathf.Abs(transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f &&
                Mathf.Abs(transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.5f)
            {
                transform.localPosition = new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localPosition.z);
            }
        }

    }

}
