using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    //reference to a rigidbody component
    private Rigidbody _rb;
    [SerializeField] private float _strength = 5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //use physics to push the loot item out of the chest
        _rb.AddForce(new Vector3(Random.Range(-2f, 2f), _strength, Random.Range(-2f, 2f)), ForceMode.Impulse);
        //use physics to spin the item out of the chest
        _rb.AddTorque(new Vector3(Random.Range(-1f, 1f), _strength, Random.Range(-1f, 1f)), ForceMode.Impulse);
    }
}
