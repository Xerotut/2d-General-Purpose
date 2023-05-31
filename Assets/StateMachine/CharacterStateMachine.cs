using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class CharacterStateMachine : MonoBehaviour
    {

        private CharacterBaseState _currentState;
        public readonly CharacterMoveState MoveState = new();
        public readonly CharacterWalkState WalkState = new();

        private void Update()
        {
            _currentState.UpdateState();
        }
        private void FixedUpdate()
        {
            _currentState.UpdateStatePhysics();
        }


        public void ChangeState(CharacterBaseState newState)
        {
            _currentState.ExitState();
            _currentState = newState;
            _currentState.EnterState();
        }



    }
}
