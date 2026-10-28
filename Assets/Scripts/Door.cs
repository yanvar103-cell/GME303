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

    [SerializeField] private string _howToOpen;//every door have it's own open requirements

    //Designer need the ability to require an item for the door(keycard)
    [SerializeField] private bool _requiresItem;
    //Reference to the required item
    [SerializeField] private InventoryManager.AllItems _requiredItem;
    
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
        if (!_isLocked)//if the door is unlocked, then open the door
        {
            _isOpen = !_isOpen; //reverse the bool(if false, set it true, if true, set it false)
            _anim.SetBool("IsOpen", _isOpen);
        }
        else //if the door is locked, stay locked and print a message that tells the player what to do
        {
            //Check if door requires an item
            if(_requiresItem)
            {
                //Check if we have the required item
                if (HasRequiredItem(_requiredItem))
                    Activate(true); //Unlock the door(Activate)
                else
                    UIMessageDisplay.Show(_howToOpen); //If we don't have the required item, check the terminal
            }
            else
                UIMessageDisplay.Show(_howToOpen);//If it doesn't require the item
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

    //Method to check if we have the required item
    public bool HasRequiredItem(InventoryManager.AllItems _itemRequired)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(_itemRequired))
            return true;
        else
            return false;
    }
}
