using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class IdleStateH : BaseStateH
    {
        private bool _isWalking;
        public IdleStateH(StateMachineH stateMachine, StateFactoryH stateFactory) : base(stateMachine, stateFactory) 
        {
            InputReader.OnWalk += status => _isWalking = status;

        }

        

        public override void UpdateStatePhysics()
        {
            if (_moveInput == Vector2.zero)
            {
                base.UpdateStatePhysics();
                return;
            }

            if (_isWalking)
            {
                _stateMachine.ChangeState(this, _masterState, _stateFactory.GetState(States.walk));
                return;
            }

            if (!_isWalking)
            {
                _stateMachine.ChangeState(this, _masterState, _stateFactory.GetState(States.run));
                return;
            }


        }

        
    }
}
