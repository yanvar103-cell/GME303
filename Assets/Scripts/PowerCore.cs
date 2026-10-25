using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCore : MonoBehaviour, IInteractable
{
    private Rigidbody _rb;
    [SerializeField] private bool _isPickedUp;
    [SerializeField] private Transform _playerPickupTransform;
    public int powerLevel;

    [SerializeField] private PowerReciever _target;
    private Material _powerCoreMaterial;

    private void Start()
    {
        _isPickedUp = false;
        _rb = GetComponent<Rigidbody>();
        _powerCoreMaterial = GetComponentInChildren<MeshRenderer>().material;
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

    public void ChangeColor()
    {
        Color newEmissionColor;
        if (powerLevel <= 0)
            newEmissionColor = Color.black;
        else if (powerLevel < _target.requiredPowerLevel * 0.3f)
            newEmissionColor = Color.magenta * 2f; //*2f is intensity glowing
        else if (powerLevel < _target.requiredPowerLevel * 0.6f)
            newEmissionColor = Color.blue * 2f;
        else if (powerLevel < _target.requiredPowerLevel)
            newEmissionColor = Color.cyan * 3f;
        else if (powerLevel == _target.requiredPowerLevel)
            newEmissionColor = Color.green * 5f;
        else
            newEmissionColor = Color.red * 5f;

        _powerCoreMaterial.SetColor("_EmissionColor", newEmissionColor);
    }

    public void Activate(bool _isActive) { }
}
