using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable //inherit from IInteractable
{
    //Reference to our InventoryManager item type
    [SerializeField] private InventoryManager.AllItems _itemType;

    public void Interact()//here we define commands when this method calls
    {
        //Add this item to the inventory manager
        InventoryManager.Instance.AddItems(_itemType);
        //Destroy gameObject
        Destroy(gameObject);
    }

    public void Activate(bool _isActive) { }
}
