using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public abstract class BaseStateH
    {
        public BaseStateH MasterState { get; protected set; }   
        protected BaseStateH _subState;
        protected StateMachineH _stateMachine;
        protected StateFactoryH _stateFactory;

        protected Rigidbody2D _charRB;
        protected CharacterStats _stats;
        

        public BaseStateH(StateMachineH stateMachine, StateFactoryH stateFactory)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;

            _charRB = _stateMachine.CharRB;
            _stats = _stateMachine.Stats;
        }

        public abstract void EnterState();

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
            MasterState = null;
        }

      
       
        
        protected void SetMasterState(BaseStateH state)
        {
            MasterState = state;
        }
        public void SetSubState(BaseStateH state)
        {
            _subState?.ExitState();
            _subState = state;
            _subState.SetMasterState(this);
            _subState.EnterState();
        }
    }
}
