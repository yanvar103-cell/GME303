using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour, IInteractable
{
    //Reference to our InventoryManager item type
    [SerializeField] private InventoryManager.AllItems _itemType;

    //Interact with the item
    public void Interact()
    {
        //Add this item to the inventory manager
        InventoryManager.Instance.AddItems(_itemType);
        //Destroy gameObject
        Destroy(gameObject);
    }

    //Add Activation code
    public void Activate(bool _isActive) { }
}
