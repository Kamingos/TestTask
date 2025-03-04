using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStateMachine : MonoBehaviour
{
    public ObjectState currentState { get; private set; }
    public event Action<ObjectState> OnChangeState;

    public void SetSearchingState() => SetState(ObjectState.Searching);
    public void SetDragState() => SetState(ObjectState.Drag);
    public void SetRestState() => SetState(ObjectState.Rest);

    private void SetState(ObjectState os)
    {
        currentState = os;
        OnChangeState.Invoke(os);
    }
}
