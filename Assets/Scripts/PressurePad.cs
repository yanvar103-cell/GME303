using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    //reference to the target
    [SerializeField] private GameObject[] _targets;
    [SerializeField] private bool _isPressed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pad"))
        {
            _isPressed = true;
            foreach (GameObject _target in _targets)
            {
                //Activate the target through a bool value
                if (_target.TryGetComponent<IInteractable>(out IInteractable _interactable))
                    _interactable.Activate(_isPressed);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pad"))
        {
            _isPressed = false;
            foreach (GameObject _target in _targets)
            {
                //Deactivate the target through a bool value
                if (_target.TryGetComponent<IInteractable>(out IInteractable _interactable))
                    _interactable.Activate(_isPressed);
            }
        }
    }

    public void Activate(bool _isActive) { }
}