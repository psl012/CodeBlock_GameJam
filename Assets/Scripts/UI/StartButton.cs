using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject Target;
    DragAroundTarget[] _dragAroundTargets;
    bool _isObjectsInCorrectPosition = true;

    // Start is called before the first frame update
    void Start()
    {
        _dragAroundTargets = Target.GetComponentsInChildren<DragAroundTarget>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickStartButton()
    {
        _isObjectsInCorrectPosition = true;

        foreach (DragAroundTarget dr in _dragAroundTargets)
        {
            _isObjectsInCorrectPosition = _isObjectsInCorrectPosition && dr.isObjectInCorrectPosition;
        }

        Debug.Log(_isObjectsInCorrectPosition);
    }
}
