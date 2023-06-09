using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class MoveInput : TransitionF
    {

        public MoveInput() 
        {
            InputReader.OnMove += input => _moveInput = input;
            InputReader.OnWalk += status => _isWalkPressed = status;
        }
        protected bool _isWalkPressed;
        protected Vector2 _moveInput;

    }

    public class ToRunMoveInput : MoveInput
    {
        public ToRunMoveInput() : base() { }
        protected override bool CheckConditionUpdate() => !_isWalkPressed && _moveInput != Vector2.zero;
    }
    public class ToWalkMoveInput : MoveInput
    {
        public ToWalkMoveInput() : base() { }
        protected override bool CheckConditionUpdate() => _isWalkPressed && _moveInput != Vector2.zero;
    }
   
}

