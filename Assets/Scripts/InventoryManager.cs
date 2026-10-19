using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Reference to the InventoryManager as a static variable
    public static InventoryManager Instance; //static means global which accessible from anywhere.

    //Create a list of all inventory items
    public List<AllItems> _inventoryItems = new List<AllItems>();
    
    //Items in an enum
    public enum AllItems
    {
        //four items(keykards)
        KeycardA,
        KeycardB,
        KeycardC,
        KeycardD,
        Box,
    }

    private void Awake()
    {
        //Get a single instance of the InventoryManager(this)
        Instance = this;
    }

    //Add collected items to the inventory list
    public void AddItems(AllItems item)
    {
        if(!_inventoryItems.Contains(item))//If the item is not in the list
        {
            _inventoryItems.Add(item);//Add the item
        }
    }

    //Remove collected items to the inventory list
    public void RemoveItems(AllItems item)
    {
        if (_inventoryItems.Contains(item))//If the item is in the list
        {
            _inventoryItems.Remove(item);//Remove the item
        }
    }
}
