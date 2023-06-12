using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class CharacterHStateMachine : StateMachineH
    {
        private Character _character;
        private Rigidbody2D _charRB;
        private Stats _stats;




        public GroundedStateH GroundedState { get; private set; }
        public IdleStateH IdleState { get; private set; }
        public RunStateH RunState { get; private set; }
        public WalkStateH WalkState { get; private set; }


        private void Awake()
        {
            _character = GetComponent<Character>();
            _stats = _character.Stats;

            _charRB = GetComponent<Rigidbody2D>();

            GroundedState = new GroundedStateH(this, _stats, _charRB);
            IdleState = new IdleStateH(this, _stats, _charRB);
            RunState = new RunStateH(this, _stats, _character, _charRB);
            WalkState = new WalkStateH(this, _stats, _character, _charRB);


            Init(GroundedState);
        }

    }
}
