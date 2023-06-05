using System;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class RunStateH : BaseStateH
    {

        private event Action<float> HandleMoveInput;

        public RunStateH(StateMachineH stateMachine, StateFactoryH stateFactory) : base(stateMachine, stateFactory) 
        {
            HandleMoveInput += speed => _stateMachine.Character.MoveEvent?.Invoke(speed);
        }

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
            HandleMoveInput?.Invoke(_stateMachine.Stats.RunSpeed);
            if (_stateMachine.CharRB.velocity == Vector2.zero)
            {
                _stateMachine.ChangeState(this, _masterState, _stateFactory.GetState(States.idle));
                return;
            }
            base.UpdateStatePhysics();
        }

        
    }
}
