using System.Collections;
using System.Collections.Generic;
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

        private Rigidbody2D _charRB;
        private Vector2 _moveInput;

        public override bool CheckCondition() => _charRB.velocity == Vector2.zero && _moveInput==Vector2.zero;
    }
}
