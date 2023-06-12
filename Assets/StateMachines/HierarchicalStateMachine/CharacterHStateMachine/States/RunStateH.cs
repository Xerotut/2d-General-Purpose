using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace GeneralPurpose2d
{
    public class RunStateH : CharacterHState
    {
        

        private event Action<float> HandleMoveInput;

        public RunStateH(CharacterHStateMachine stateMachine, Stats stats, Character character, Rigidbody2D charRB) : base(stateMachine, stats, charRB) 
        {
            HandleMoveInput += speed => character.MoveEvent?.Invoke(speed);
        }

      

        public override void UpdateStatePhysics()
        {
            HandleMoveInput?.Invoke(_stats.RunSpeed);
            
            if (_charRB.velocity == Vector2.zero)
            {
                _stateMachine.ChangeState(this, _masterState, _stateMachine.IdleState);
                return;
            }

            if (_isWalking)
            {
                _stateMachine.ChangeState(this, _masterState, _stateMachine.WalkState);
                return;
            }
           
            base.UpdateStatePhysics();
        }

        
    }
}
