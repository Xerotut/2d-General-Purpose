using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class StateMachineH : MonoBehaviour
    {

        [SerializeField] CharacterMovement _movementScript;
        public CharacterMovement MovementScript { get => _movementScript; }

        private BaseStateH _currentState;

        private StateFactoryH _factory;

        public Vector2 DirectionInput { get; private set; }

        [SerializeField] CharacterStats _stats;
        public CharacterStats Stats { get => _stats; }

        public Rigidbody2D CharRB { get; private set; }

        private void Awake()
        {
            CharRB = GetComponent<Rigidbody2D>();
            _factory = new StateFactoryH(this);
            _currentState = _factory.GetState(States.grounded);
            _currentState.EnterState();

            InputReader.OnMove += vector => DirectionInput = vector;
        }

        private void Update()
        {
            _currentState.UpdateState();
        }

        private void FixedUpdate()
        {
            _currentState.UpdateStatePhysics();
        }


        public void ChangeState(BaseStateH stateToChange, BaseStateH newState)
        {
            if (stateToChange.MasterState == null) 
            {
                _currentState.ExitState();
                _currentState = newState;
                _currentState.EnterState();
            }
            else
            {
               // if (activeState.MasterState != null) Debug.Log("halo");
              //  Debug.Log(stateToChange.MasterState);
                stateToChange.MasterState.SetSubState(newState);
                
            }
        }

    }
}
