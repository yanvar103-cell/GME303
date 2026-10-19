using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool _isOpen;
    private Animator _anim;
    //reference to toggle the door lock
    [SerializeField] private bool _isLocked;
    [SerializeField] private GameObject[] _doorPanels;
    
    void Start()
    {
        _anim = GetComponent<Animator>();
        if (_isLocked)
        {
            _doorPanels[0].SetActive(true);
            _doorPanels[1].SetActive(false);
        }
        else
        {
            _doorPanels[0].SetActive(false);
            _doorPanels[1].SetActive(true);
        }
    }

    public void Interact()
    {
        //if the door is locked, stay locked and print a message that tells the player what to do
        //if the door is unlocked, then open the door
        if (!_isLocked)
        {
            _isOpen = !_isOpen; //reverse the bool(if false, set it true, if true, set it false)
            _anim.SetBool("IsOpen", _isOpen);
        }
        else
        {
            Debug.Log("Locked! Check the terminal");
        }
    }

    public void Activate(bool _isActive)
    {
        UnlockDoor(_isActive);//lock/unlock the door
    }

    private void UnlockDoor(bool _isActive)
    {
        _isLocked = !_isActive;
        if (_isLocked)
        {
            _doorPanels[0].SetActive(true);
            _doorPanels[1].SetActive(false);
        }
        else
        {
            _doorPanels[0].SetActive(false);
            _doorPanels[1].SetActive(true);
        }
    }
}
