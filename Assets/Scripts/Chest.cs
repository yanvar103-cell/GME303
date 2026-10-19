using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private bool _isOpen;
    private Animator _anim;
    [SerializeField] private bool _isLocked;
    private bool _interacted;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    //Use IInteractable to open the chest
    public void Interact()
    {
        if(!_isLocked)
        {
            _isOpen = !_isOpen;
            _anim.SetBool("IsOpen", _isOpen);
            //spawn loot
            if(!_interacted)
            {
                _interacted = true;
                if (TryGetComponent<SpawnLoot>(out SpawnLoot _spawnLoot))
                    _spawnLoot._isSpawned = true;
            }
        }
    }

    public void Activate(bool _isActive) { }//activate method to match interface signature
}
