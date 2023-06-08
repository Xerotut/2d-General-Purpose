using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Character))]
    public class CharacterStateMachineF : StateMachineF
    {

        private Character _character;
        public Character Character { get => _character; }

        private Rigidbody2D _charRB;

        private void Awake()
        {
            _character = GetComponent<Character>();
            _charRB = GetComponent<Rigidbody2D>();

            StateF idleState = new IdleStateF();
            StateF runState = new RunStateF(_character, _character.Stats.RunSpeed);
            StateF walkState = new WalkStateF(_character, _character.Stats.WalkSpeed);

            TransitionF toRunTransition = new ToRunMoveInput();
            TransitionF toWalkTransition = new ToWalkMoveInput();
            TransitionF stopMovingTransition = new CharacterIsNotMoving(_charRB);

            Init(idleState, new()
            {
                { idleState, new(){ { toRunTransition, runState }, {toWalkTransition, walkState } } },
                { runState, new(){ {stopMovingTransition, idleState }, { toWalkTransition, walkState} } },
                { walkState, new(){ {stopMovingTransition, idleState }, { toRunTransition, runState} } },
            });
        }

    }
}
