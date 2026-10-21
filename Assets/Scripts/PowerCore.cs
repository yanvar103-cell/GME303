using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCore : MonoBehaviour, IInteractable
{
    private Rigidbody _rb;
    [SerializeField] private bool _isPickedUp;
    [SerializeField] private Transform _playerPickupTransform;

    private void Start()
    {
        _isPickedUp = false;
        _rb = GetComponent<Rigidbody>();
    }

    public void Interact()
    {
        //Check if picked up or dropped
        if(!_isPickedUp)
        {
            _isPickedUp = true;
            //Turn off physics gravity when picked up
            _rb.isKinematic = true;
            
            //Update the position of the power core to a pickup transform on the player
            transform.position = _playerPickupTransform.position;
            transform.rotation = _playerPickupTransform.rotation;
            
            //Set the Player as the parent when picked up
            transform.SetParent(_playerPickupTransform);
        }
        else
        {
            _isPickedUp = false;
            //Turn off physics gravity when picked up
            _rb.isKinematic = false;
            
            //Reset the parent back to the world on drop
            transform.SetParent(null);
        }
    }

    public void Activate(bool _isActive) { }
}
