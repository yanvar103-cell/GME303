using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour, IInteractable
{
    //reference to the material via the meshRenderer
    private Material _emissiveMaterial;
    [SerializeField] private bool _isOn;
    [SerializeField] private float _emissionPower = 5f;
    
    private void Start()
    {
        _emissiveMaterial = GetComponent<MeshRenderer>().materials[1];
        //Create some functionality for the designer(must it be on at start?)
        if (_isOn)
            _emissiveMaterial.SetColor("_EmissionColor", Color.white * _emissionPower);
        else
            _emissiveMaterial.SetColor("_EmissionColor", Color.black);
    }

    public void Interact() //Toggle light on/off via emissive material
    {
        if (_isOn)
            _emissiveMaterial.SetColor("_EmissionColor", Color.white * _emissionPower);
        else
            _emissiveMaterial.SetColor("_EmissionColor", Color.black);
        _isOn = !_isOn;
    }
}
