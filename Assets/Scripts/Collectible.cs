using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    //OnTriggerEnter, collect the item
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Modify a player stat
            Debug.Log("add Health");

            //Destroy this gameObject
            Destroy(gameObject);
        }
    }
}
