using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable //inherit from IInteractable
{
    void Start()
    {
        Debug.Log("This is a pickup item");
    }

    public void Interact()//here we define commands when this method calls
    {
        Debug.Log("Interacting with" + gameObject.name);
    }

    public void Activate() { }
}
