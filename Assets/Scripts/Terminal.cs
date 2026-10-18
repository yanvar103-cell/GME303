using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    //get target reference
    [SerializeField] private GameObject[] _targets;
    //create a reference to power up the terminal(with electricity)
    [SerializeField] private bool _isPowered;

    //On Interact
    public void Interact()
    {
        //get all of the targets
        //foreach target
        foreach(GameObject _target in _targets)
        {
            if(_target.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                Debug.Log(_target.name + " is powered up!");
                //activate those targers via a new method
                interactable.Activate();
            }
        }
    }

    public void Activate()
    {
        //if powered off, then activate the terminal
    }

}
