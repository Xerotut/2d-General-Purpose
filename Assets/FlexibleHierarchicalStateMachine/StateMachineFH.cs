using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GeneralPurpose2d
{
    public class StateMachineFH : MonoBehaviour
    {

        private StateFH _currentState;


        protected void Init(StateFH initialState, Dictionary<StateFH, Dictionary<TransitionFH, StateFH>> states)
        {
            foreach (var state in states)
            {
                foreach (var transition in state.Value)
                {
                    transition.Key.Callback += () => ChangeState(state.Key, state.Key.MasterState ,transition.Value);
                    state.Key.AddTransition(transition.Key);
                }
            }
           
            ChangeState(null, null, initialState);

        }

        private void Update() => _currentState?.UpdateState();
        private void FixedUpdate() => _currentState?.UpdateStatePhysics();
        private void ChangeState(StateFH stateToChange, StateFH masterState,StateFH newState)
        {
            stateToChange?.Exit();

            if (masterState == null)
            {
                _currentState = newState;
            }
            else
            {
                masterState.SetSubState(newState);
            }
            newState.Enter();

        }
    }
}
