using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class IdleStateH : BaseStateH
    {
        public IdleStateH(StateMachineH stateMachine, StateFactoryH stateFactory) : base(stateMachine, stateFactory) { }

        public override void EnterState()
        {
          //  Debug.Log("Entered idle state");
        }

        public override void ExitState()
        {
          //  Debug.Log("Exited idle state");
            base.ExitState();
        }

        public override void UpdateState()
        {
          //  Debug.Log(MasterState);
            if (_stateMachine.DirectionInput != Vector2.zero) _stateMachine.ChangeState(this, _stateFactory.GetState(States.run));
            base.UpdateState();
        }

        public override void UpdateStatePhysics()
        {
            
            base.UpdateStatePhysics();
        }

        
    }
}
