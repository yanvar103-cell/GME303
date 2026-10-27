using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-100)] // run before the player controller

public class Elevator : MonoBehaviour, IInteractable
{
    //Multi-levels
    public Transform[] elevatorLevels;
    //Drive the speed of the elevator
    [SerializeField] private float _elevatorSpeed = 10f;
    public bool _isPoweredUp;
    [SerializeField] private string _howToActivate;
    [SerializeField] private bool _isCalled;

    //Check which level we're currently at
    //Determine which level to go to next
    [SerializeField] private int _nextLevelIndex;

    //Reference to the Player Input
    private PlayerInput _playerInput;
    //Reference to the Elevator UI
    [SerializeField] private GameObject _elevatorUI;

    private void Awake()
    {
        _playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
        _elevatorUI.SetActive(false);
    }

    //Move the elevator to the next position
    private void Update()
    {
        if (!_isCalled) return;
        if (!_isPoweredUp) return;

        Vector3 target = elevatorLevels[_nextLevelIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, elevatorLevels[_nextLevelIndex].position, Time.deltaTime * _elevatorSpeed);

        // Sync the CharacterController's capsule with its new (parented) position
        Physics.SyncTransforms();

        if (transform.position == target) // checked AFTER moving
        {
            _isCalled = false;
            _nextLevelIndex = (_nextLevelIndex + 1) % elevatorLevels.Length;
        }
    }

    public void Interact()
    {
        //Check if the elevator activated
        if (_isPoweredUp && !_isCalled)
        {
            //Show the Elevator UI
            _elevatorUI.SetActive(true);
            //Activate UI action map
            _playerInput.SwitchCurrentActionMap("UI");
        }
        else
        {
            Debug.Log(_howToActivate);
            UIMessageDisplay.Show(_howToActivate);
        }
    }

    public void Activate(bool _isActive)
    {
        _isPoweredUp = _isActive;
    }

    //New method to check floor int value from OnClick event
    public void ChooseFloor(int floorValue)
    {
        //Choose the floor
        _nextLevelIndex = floorValue;
        //Hide the elevator UI
        _elevatorUI.SetActive(false);
        //Switch the action map back to Player
        _playerInput.SwitchCurrentActionMap("Player");
        _isCalled = true;
    }
}
