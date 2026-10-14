using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;//attach here mainCamera
    
    private void LateUpdate()
    {
        //LookAt method to change the orientation of the UI by Y axis
        //object looks to the target by it's face(z axis)
        transform.LookAt(_cameraTransform);
    }
}
