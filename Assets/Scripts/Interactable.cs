using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject _UIContainer;

    private void Awake()
    {
        if (_UIContainer != null) _UIContainer.SetActive(false);
    }

    /*
    //OnTriggerEnter, collect the item
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Modify a player stat
            Debug.Log("add Health");

            //Destroy this gameObject
            Destroy(gameObject);
        }
    }
    */

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Show UI
            if (_UIContainer != null) _UIContainer.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)) Debug.Log("Interacted");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Hide UI
        if (_UIContainer != null) _UIContainer.SetActive(false);
    }
}
