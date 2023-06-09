using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace GeneralPurpose2d
{
    public enum States
    {
        grounded,
        airborne,
        idle,
        run,
        walk,
        stunned,
        fly,
        fall
    }

    public class StateFactoryH
    {
        private readonly StateMachineH _stateMachine;

        private readonly Dictionary<States, BaseStateH> _states = new();

        public StateFactoryH(StateMachineH stateMachine)
        {
            _stateMachine = stateMachine;
            _states[States.grounded] = new GroundedStateH(_stateMachine, this);
            _states[States.run] = new RunStateH(_stateMachine, this);
            _states[States.idle] = new IdleStateH(_stateMachine, this);
            //_states[States.grounded] = new GroundedState(_stateMachine, this);
            //_states[States.idle] = new IdleState(_stateMachine, this);
            _states[States.walk] = new WalkStateH(_stateMachine, this);
            //_states[States.move] = new MoveState(_stateMachine, this);
            //_states[States.stunned] = new StunnedState(_stateMachine, this);
        }

        public BaseStateH GetState(States state)
        {
            try
            {
                return _states[state];
            }
            catch (Exception exception)
            {
                Debug.Log(exception.Message);
                return _states[States.grounded];
            }
        }
    }
}
