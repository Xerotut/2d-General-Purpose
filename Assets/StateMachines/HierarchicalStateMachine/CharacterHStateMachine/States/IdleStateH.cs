using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class IdleStateH : CharacterHState
    {
        public IdleStateH(CharacterHStateMachine stateMachine, Stats stats, Rigidbody2D charRB) : base(stateMachine, stats, charRB) { }
        

        

        public override void UpdateStatePhysics()
        {
            base.UpdateStatePhysics();
            if (_moveInput == Vector2.zero)
            {
                return;
            }

            if (_isWalking)
            {
                _stateMachine.ChangeState(this, _masterState, _stateMachine.WalkState);
                return;
            }

            if (!_isWalking)
            {
                _stateMachine.ChangeState(this, _masterState, _stateMachine.RunState);
                return;
            }

        }

        
    }
}
