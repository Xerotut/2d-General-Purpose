using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class StateMachineH: MonoBehaviour
    {
        [SerializeField] private Character _character;
        public Character Character { get => _character; }

        [SerializeField] private Rigidbody2D _charRB;
        public Rigidbody2D CharRB { get => _charRB; }

        [SerializeField] private CharacterStats _stats;
        public CharacterStats Stats { get => _stats; }


        


        private StateFactoryH _factory;
        private BaseStateH _currentState;






        private void Awake()
        {
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
