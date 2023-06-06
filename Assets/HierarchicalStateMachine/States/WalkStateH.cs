using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class WalkStateH : BaseStateH
    {
        private bool _isWalking;
        private event Action<float> HandleMoveInput;
        public WalkStateH(StateMachineH stateMachine, StateFactoryH stateFactory) : base(stateMachine, stateFactory)
        {
            HandleMoveInput += speed => _stateMachine.Character.MoveEvent?.Invoke(speed);
            InputReader.OnWalk += status => _isWalking = status;
        }

        public override void UpdateStatePhysics()
        {
            if (_isWalking && _stateMachine.CharRB.velocity != Vector2.zero)
            {
                HandleMoveInput?.Invoke(_stateMachine.Stats.WalkSpeed);
                base.UpdateStatePhysics();
                return;
            }

            if (_stateMachine.CharRB.velocity == Vector2.zero)
            {
                _stateMachine.ChangeState(this, _masterState, _stateFactory.GetState(States.idle));
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
