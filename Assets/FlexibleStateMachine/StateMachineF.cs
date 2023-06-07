using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public abstract class StateMachineF : MonoBehaviour
    {
        private StateF _currentState;


        protected void Init(StateF initialState, Dictionary<StateF, Dictionary<TransitionF, StateF>> states)
        {
            foreach (var state in states)
            {
                foreach (var transition in state.Value)
                {
                    transition.Key.Callback += () => ChangeState(transition.Value);
                    state.Key.AddTransition(transition.Key);
                }
            }

            ChangeState(initialState);
        }

        private void Update() => _currentState?.UpdateState();
        private void FixedUpdate() => _currentState?.UpdateStatePhysics();

        private void ChangeState(StateF newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

    }
}
