using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class GroundedStateH : BaseStateH
    {
        public GroundedStateH(StateMachineH stateMachine, StateFactoryH stateFactory) : base(stateMachine, stateFactory) { }

        public override void EnterState()
        {
            if (_stateMachine.DirectionInput == Vector2.zero)
            {
                SetSubState(_stateFactory.GetState(States.idle));
                return;
            }
            if (_stateMachine.DirectionInput != Vector2.zero)
            {
                SetSubState(_stateFactory.GetState(States.run));
                return;
            }
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
            
            base.UpdateState();
        }

        public override void UpdateStatePhysics()
        {
            base.UpdateStatePhysics();
        }
    }
}
