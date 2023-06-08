using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class CharacterIsNotMoving :  TransitionF
    {
        public CharacterIsNotMoving(Rigidbody2D charRB)
        {
            _charRB = charRB;
            InputReader.OnMove += input => _moveInput = input;
        }

        private readonly Rigidbody2D _charRB;
        private Vector2 _moveInput;

        protected override bool CheckConditionUpdate() => _moveInput == Vector2.zero;
        protected override bool CheckConditionFixedUpdate() => _charRB.velocity==Vector2.zero;

        

       
    }
}
