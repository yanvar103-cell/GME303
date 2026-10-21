using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBase : MonoBehaviour
{
    [SerializeField] private Transform _snapPoint;
    private PowerCore _currentCore;

    private void OnCollisionEnter(Collision collision)
    {
        if (_currentCore != null) return; // already holding one
        if (collision.gameObject.CompareTag("PowerCore"))
        {
            PowerCore core = collision.gameObject.GetComponent<PowerCore>();
            Debug.Log("Power Core Detected!");
            //Match the transform of the power core to the power base
            //collision.transform.position = _snapPoint.position;
            //collision.transform.rotation = _snapPoint.rotation;

            _currentCore = core;
            core.SnapTo(_snapPoint, this);
        }
    }

    public void ReleaseCore(PowerCore core)
    {
        if (_currentCore == core)
        {
            Debug.Log("Power Core Removed!");
            _currentCore = null;
        }
    }
}
