using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerReciever : PowerBase //Inherit from the PowerBase
{
    //Allow designer to input the required power level
    public int requiredPowerLevel;

    //have a target be powered up by the reciever(elevator)
    [SerializeField] private GameObject[] _targets;
    [SerializeField] private bool _isActivated;

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        //Check if the power core is on the reciever
        if (collision.gameObject.CompareTag("PowerCore"))
        {
            //Check if the power level is sufficient
            int powerCoreValue =  collision.gameObject.GetComponent<PowerCore>().powerLevel;
            if (powerCoreValue == requiredPowerLevel)
            {
                Debug.Log("Sufficient power!");
                _isActivated = true;
                foreach (GameObject _target in _targets)
                {
                    if (_target.TryGetComponent<IInteractable>(out IInteractable interactable))
                        interactable.Activate(_isActivated);
                }
            }
            else if (powerCoreValue > requiredPowerLevel)
                Debug.Log("Too much power!");
            else
                Debug.Log("Insufficient power!");
        }
    }

    public override void OnCollisionExit(Collision collision)
    {
        base.OnCollisionExit(collision);
        _isActivated = false;
    }
}
