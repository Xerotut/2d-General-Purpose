using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public abstract class BaseStateH
    {
        public BaseStateH(StateMachineH stateMachine, StateFactoryH stateFactory)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;

            InputReader.OnMove += input => _moveInput = input;
        }

        protected BaseStateH _masterState;
        protected BaseStateH _subState;
        protected StateMachineH _stateMachine;
        protected StateFactoryH _stateFactory;

        protected Vector2 _moveInput;
        protected Stats _stats;
        

      

        public virtual void EnterState()
        {
            _subState = null;
        }

        public virtual void UpdateState()
        {
            _subState?.UpdateState();
        }

        public virtual void UpdateStatePhysics()
        {
            _subState?.UpdateStatePhysics();
        }

        public virtual void ExitState()
        {
            _subState?.ExitState();
            _masterState = null;
        }

      
       
        
        protected void SetMasterState(BaseStateH state)
        {
            _masterState = state;
        }
        public void SetSubState(BaseStateH state)
        {
            _subState = state;
            _subState.SetMasterState(this);
        }
    }
}
