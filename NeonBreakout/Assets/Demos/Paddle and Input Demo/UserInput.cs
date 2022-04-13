using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserInput : MonoBehaviour
{
    public UnityEvent OnUpInput;
    public UnityEvent OnDownInput;
    public UnityEvent OnLeftInput;
    public UnityEvent OnRightInput;
    public UnityEvent OnEscapeInput;
    public UnityEvent OnEnterInput;
    public UnityEvent OnSpaceInput;

    private void Update()
    {
        GetUserInput();
    }
    
    private void GetUserInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OnSpaceInput.Invoke();
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            OnEnterInput.Invoke();
        if (Input.GetKeyDown(KeyCode.Escape))
            OnEscapeInput.Invoke();
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            OnUpInput.Invoke();
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            OnDownInput.Invoke();
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            OnLeftInput.Invoke();
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            OnRightInput.Invoke();
    }
}
