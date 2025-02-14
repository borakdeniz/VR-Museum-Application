using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ClimbProvider : MonoBehaviour
{
    public static event Action ClimbActive;
    public static event Action ClimbInactive;

    public CharacterController characterController;
    public InputActionProperty velocityRight;
    public InputActionProperty velocityLeft;

    private bool _rightActive = false;
    private bool _leftActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        XRDirectClimbInteractor.ClimbHandActivated += HandActivated;
        XRDirectClimbInteractor.ClimbHandDeactivated += HandDeactivated;
    }

    private void OnDestroy()
    {
        XRDirectClimbInteractor.ClimbHandActivated -= HandActivated;
        XRDirectClimbInteractor.ClimbHandDeactivated -= HandDeactivated;
    }

    private void HandActivated(string _controllerName)
    {
        if(_controllerName == "Left Controller")
        {
            _leftActive = true;
            _rightActive = false;
        }
        else
        {
            _leftActive = false;
            _rightActive = true;
        }
        ClimbActive?.Invoke();
    }
    private void HandDeactivated(string _controllerName) 
    {
        if (_rightActive && _controllerName == "Right Controller")
        {
            _rightActive = false;
            ClimbActive?.Invoke();
        }
        else if (_leftActive && _controllerName == "Left Controller")
        {
            _leftActive = false;
            ClimbActive?.Invoke();
        }
        ClimbActive?.Invoke();
    }

    private void FixedUpdate()
    {
        if (_rightActive || _leftActive)
        {
            Climb();
        }
    }

    private void Climb()
    {
        Vector3 velocity = _leftActive ? velocityLeft.action.ReadValue<Vector3>() : velocityRight.action.ReadValue<Vector3>();
        characterController.Move(characterController.transform.rotation * -velocity * Time.fixedDeltaTime);

    }
}
