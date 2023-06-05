using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class RunStateH : BaseStateH
    {
        public RunStateH(StateMachineH stateMachine, StateFactoryH stateFactory) : base(stateMachine, stateFactory) { }

        public override void EnterState()
        {
           // Debug.Log("Entered run state");
        }

        public override void ExitState()
        {
          //  Debug.Log("Exited run state");
            base.ExitState();
        }

        public override void UpdateState()
        {
           
            base.UpdateState();
        }

        public override void UpdateStatePhysics()
        {
            _stateMachine.MovementScript.Move(_charRB, _stats.RunSpeed, _stateMachine.DirectionInput);
            if (_charRB.velocity == Vector2.zero)
            {
                _stateMachine.ChangeState(this, _stateFactory.GetState(States.idle));
                return;
            }
            base.UpdateStatePhysics();
        }

        
    }
}
