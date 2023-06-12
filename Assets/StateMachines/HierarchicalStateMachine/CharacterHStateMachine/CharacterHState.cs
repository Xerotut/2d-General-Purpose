using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class CharacterHState : StateH
    {
        public CharacterHState(CharacterHStateMachine stateMachine, Stats stats, Rigidbody2D charRB)
        {
            InputReader.OnMove += input => _moveInput = input;
            InputReader.OnWalk += status => _isWalking = status;
            _stats = stats;
            _stateMachine = stateMachine;
            _charRB = charRB;
        }

        protected Vector2 _moveInput;
        protected bool _isWalking;

        protected Stats _stats;
        protected CharacterHStateMachine _stateMachine;

        protected Rigidbody2D _charRB;

    }
}
