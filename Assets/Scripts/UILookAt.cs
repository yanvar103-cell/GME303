using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    private Transform _cameraTransform;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        //LookAt method to change the orientation of the UI by Y axis
        //object looks to the target by it's face(z axis)
        transform.LookAt(_cameraTransform);
    }
}
