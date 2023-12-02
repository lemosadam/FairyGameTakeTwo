using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private string currentStateName;
    //private IPlayerState currentState;

    //public DefaultState defaultState = new DefaultState();

    private void OnEnable()
    {
        //currentState = defaultState();
    }

    // Update is called once per frame
    void Update()
    {
        //currentState = currentState.DoState(this);
        //currentStateName = currentState.ToString();
    }
}
