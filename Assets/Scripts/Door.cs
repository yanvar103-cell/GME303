using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool _isOpen;
    private Animator _anim;
    
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Interact()
    {
        _isOpen = !_isOpen; //reverse the bool(if false, set it true, if true, set it false)
        _anim.SetBool("IsOpen", _isOpen);
    }
}
