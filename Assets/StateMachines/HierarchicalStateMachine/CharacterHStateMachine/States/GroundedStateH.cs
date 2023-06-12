using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class GroundedStateH : CharacterHState
    {
        public GroundedStateH(CharacterHStateMachine stateMachine, Stats stats, Rigidbody2D charRB) : base(stateMachine, stats, charRB) { }

        public override void EnterState()
        {
            base.EnterState();
            if (_moveInput == Vector2.zero)
            {
                SetSubState(_stateMachine.IdleState);
                return;
            }

            if (_moveInput != Vector2.zero && !_isWalking)
            {
                SetSubState(_stateMachine.RunState);
                return;
            }
            if (_moveInput != Vector2.zero && _isWalking)
            {
                SetSubState(_stateMachine.WalkState);
                return;
            }
        }

    }
}
