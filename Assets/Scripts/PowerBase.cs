using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBase : MonoBehaviour
{
    [SerializeField] private Transform _snapPoint;
    private bool _isBusy = false;

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (_isBusy) return; // already holding one
        if (collision.gameObject.CompareTag("PowerCore"))
        {
            _isBusy = true;
            Debug.Log("Power Core Detected!");
            //Match the transform of the power core to the power base
            collision.transform.position = _snapPoint.position;
            collision.transform.rotation = _snapPoint.rotation;
        }
    }

    public virtual void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PowerCore"))
        {
            _isBusy = false;
            Debug.Log("Power Core Removed!");
        }
    }
}
