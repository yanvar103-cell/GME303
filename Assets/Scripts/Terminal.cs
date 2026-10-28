using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    //get target reference
    [SerializeField] private GameObject[] _targets;
    //create a reference to power up the terminal(with electricity)
    [SerializeField] private bool _isPowered;
    //Reference to the terminalFloorIndex;
    [SerializeField] private int _terminalFloorIndex;
    [SerializeField] private string _howToOpen;

    //On Interact
    public void Interact()
    {
        //get all of the targets
        //foreach target
        if (_isPowered)
        {
            foreach (GameObject _target in _targets)
            {
                if (_target.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    UIMessageDisplay.Show(_target.name + " is powered up!");
                    //activate those targers via a new method
                    interactable.Activate(_isPowered);
                    //Try to get the elevator component, if true call chooseFloor method
                    if (_target.TryGetComponent<Elevator>(out Elevator elevator))
                    {
                        elevator.ChooseFloor(_terminalFloorIndex);
                        UIMessageDisplay.Show(_target.name + " is coming!");
                    }
                }
            }
        }
        else
            UIMessageDisplay.Show(_howToOpen);
    }

    public void Activate(bool _isActive)
    {
        //if powered off, then activate the terminal
        _isPowered = _isActive;
    }
}
