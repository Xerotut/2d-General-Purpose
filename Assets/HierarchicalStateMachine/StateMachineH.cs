using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class StateMachineH: MonoBehaviour
    {
       
        public Character Character { get; private set; }
        public Rigidbody2D CharRB { get; private set; }
        public CharacterStats Stats { get; private set; }

        private StateFactoryH _factory;
        private BaseStateH _currentState;

        private void Awake()
        {
            Character = GetComponent<Character>();
            Stats = Character.Stats;

            CharRB = GetComponent<Rigidbody2D>();

            _factory = new StateFactoryH(this);
            _currentState = _factory.GetState(States.grounded);
            _currentState.EnterState();
        }

        private void Update()
        {
            _currentState.UpdateState();
        }

        private void FixedUpdate()
        {
            _currentState.UpdateStatePhysics();
        }

        public void ChangeState(BaseStateH stateToChange, BaseStateH masterState, BaseStateH newState)
        {
            
            stateToChange.ExitState();

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
