using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Character))]
    public class CharacterFHStateMachine : StateMachineFH
    {

        private Character _character;
        public Character Character { get => _character; }

        private Rigidbody2D _charRB;

        private void Awake()
        {
            _character = GetComponent<Character>();
            _charRB = GetComponent<Rigidbody2D>();
        }
    }
}
