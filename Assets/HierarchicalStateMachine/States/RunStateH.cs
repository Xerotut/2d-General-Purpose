using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace GeneralPurpose2d
{
    public class RunStateH : BaseStateH
    {
        private bool _isWalking;

        private event Action<float> HandleMoveInput;

        public RunStateH(StateMachineH stateMachine, StateFactoryH stateFactory) : base(stateMachine, stateFactory) 
        {
            HandleMoveInput += speed => _stateMachine.Character.MoveEvent?.Invoke(speed);
            InputReader.OnWalk += status => _isWalking = status;
        }

      

        public override void UpdateStatePhysics()
        {
            HandleMoveInput?.Invoke(_stateMachine.Stats.RunSpeed);
            
            if (_stateMachine.CharRB.velocity == Vector2.zero)
            {
                _stateMachine.ChangeState(this, _masterState, _stateFactory.GetState(States.idle));
                return;
            }

            if (_isWalking)
            {
                _stateMachine.ChangeState(this, _masterState, _stateFactory.GetState(States.walk));
                return;
            }
           
            base.UpdateStatePhysics();
        }

        
    }
}
