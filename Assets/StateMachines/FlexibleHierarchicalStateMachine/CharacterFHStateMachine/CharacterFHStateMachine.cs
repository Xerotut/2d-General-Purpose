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

            StateFH idleState = new IdleStateFH();
            StateFH runState = new RunStateFH(_character, _character.Stats.RunSpeed);
            StateFH walkState = new WalkStateFH(_character, _character.Stats.WalkSpeed);
            StateFH groundedState = new GroundedStateFH();

            TransitionF idleToRun = new ToRunMoveInput();
            TransitionF walkToRun = new ToRunMoveInput();
            TransitionF idleToWalk = new ToWalkMoveInput();
            TransitionF runToWalk = new ToWalkMoveInput();
            TransitionF runToIdle = new CharacterIsNotMoving(_charRB);
            TransitionF walkToIdle = new CharacterIsNotMoving(_charRB);

            TransitionF groundedRunSubstate = new ToRunMoveInput();
            TransitionF groundedWalkSubstate = new ToWalkMoveInput();
            TransitionF groundedIdleSubstate = new CharacterIsNotMoving(_charRB);

            Init(idleState, new()
            {
                { idleState, new(){ { idleToRun, runState }, { idleToWalk, walkState } } },
                { runState, new(){ { runToIdle, idleState }, { runToWalk, walkState} } },
                { walkState, new(){ { walkToIdle, idleState }, { walkToRun, runState} } },
            }, new()
            {
                {groundedState, new() { { groundedRunSubstate, runState  }, { groundedWalkSubstate, walkState}, { groundedIdleSubstate, idleState} } }
            });
        }
    }
}
