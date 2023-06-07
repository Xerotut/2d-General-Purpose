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
        }

        private Vector2 _moveInput;
        public override bool CheckCondition() => _moveInput != Vector2.zero;
            
        
        
    }
}
