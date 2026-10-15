using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject _UIContainer;
    //referencing for IInteractable, because we use it here for all type interactables(pickups, doors, etc.)
    private IInteractable _interactable;
    private bool _isInteractable;

    private void Awake()
    {
        if (_UIContainer != null) _UIContainer.SetActive(false);
        _interactable = GetComponent<IInteractable>();
        _isInteractable = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_UIContainer != null)
                _UIContainer.SetActive(true); //Show UI
            _isInteractable = true;
        }
    }

    private void Update()
    {
        if (_isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            _interactable.Interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Hide UI
            if (_UIContainer != null)
                _UIContainer.SetActive(false);
            _isInteractable = false;
        }
    }
}
