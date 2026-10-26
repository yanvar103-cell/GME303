using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeParentTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _vCam;
    private Cinemachine3rdPersonFollow _3PersonFollow;
    private Vector3 _vCamDampingOrig;
    private float _vCamDistOrig;
    [SerializeField] private float _vCamDistElevator;//set in inspector

    private void Start()
    {
        _3PersonFollow = _vCam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        _vCamDampingOrig = _3PersonFollow.Damping;
        _vCamDistOrig = _3PersonFollow.CameraDistance;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
            //Change the camera distance
            _3PersonFollow.CameraDistance = _vCamDistElevator;
            //Set the damping to 0
            _3PersonFollow.Damping = new Vector3(_vCamDampingOrig.x, 0, _vCamDampingOrig.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
            //Revert all camera changes to original
            _3PersonFollow.CameraDistance = _vCamDistOrig;
            _3PersonFollow.Damping = _vCamDampingOrig;
        }
    }
}
