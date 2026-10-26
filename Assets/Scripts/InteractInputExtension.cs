using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class InteractInputExtension : MonoBehaviour
{
    private StarterAssetsInputs _starterAssetsInputs;

    private void Awake()
    {
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void LateUpdate()
    {
        _starterAssetsInputs.interact = false; //sets it to false right after interacting
    }
}
