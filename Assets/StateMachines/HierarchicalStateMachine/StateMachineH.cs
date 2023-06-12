using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class StateMachineH: MonoBehaviour
    {

        private StateH _currentState;


        private void Update() => _currentState.UpdateState();

        private void FixedUpdate() => _currentState.UpdateStatePhysics();


        protected void Init(StateH _defaultState)
        {
            ChangeState(null, null, _defaultState);
        }

        public void ChangeState(StateH stateToChange, StateH masterState, StateH newState)
        {
            
            stateToChange?.ExitState();

            if (masterState==null) 
            {
                _currentState = newState;
            }
            else
            {
                masterState.SetSubState(newState);
            }
            newState.EnterState();

        }

    }
}
