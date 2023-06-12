using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class WalkStateH : CharacterHState
    {
        private event Action<float> HandleMoveInput;
        public WalkStateH(CharacterHStateMachine stateMachine, Stats stats, Character character, Rigidbody2D charRB) : base(stateMachine, stats, charRB)
        {
            HandleMoveInput += speed => character.MoveEvent?.Invoke(speed);
        }

        public override void UpdateStatePhysics()
        {

            base.UpdateStatePhysics();
            if (!_isWalking)
            {
                _stateMachine.ChangeState(this, _masterState, _stateMachine.RunState);
                return;
            }

            if (_moveInput!=Vector2.zero || _charRB.velocity != Vector2.zero)
            {
                HandleMoveInput?.Invoke(_stats.WalkSpeed);
                return;
            }

            if (_moveInput ==Vector2.zero && _charRB.velocity == Vector2.zero )
            {
                _stateMachine.ChangeState(this, _masterState, _stateMachine.IdleState);
                return;
            }           
           
            

        }
    }
}
