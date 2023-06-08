using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace GeneralPurpose2d
{
    public class StateFH 
    {
        protected StateFH _masterState;
        public StateFH MasterState { get => _masterState; }
        protected StateFH _subState;


        private List<TransitionFH> _transitions = new();

        private List<TransitionFH> _subStateTransitions = new();

        public void AddTransition(TransitionFH transition)
        {
            _transitions.Add(transition);
        }
        public void AddSubstateTransition(TransitionFH transition)
        {
            _subStateTransitions.Add(transition);
        }

        public virtual void Enter()
        {
            for (int i = 0; i < _transitions.Count; i++)
            {
                _transitions[i].Enter();
            }
            InitSubState();
            _subState.Enter();  
        }

        public virtual void Exit()
        {
            _subState?.Exit();
            for (int i = 0; i < _transitions.Count; i++)
            {
                _transitions[i].Exit();
            }
        }

        public virtual void UpdateState()
        {
            for (int i = 0; i < _transitions.Count; i++)
            {
                _transitions[i].UpdateTransition();
            }
            _subState?.UpdateState();
        }
        public virtual void UpdateStatePhysics()
        {
            for (int i = 0; i < _transitions.Count; i++)
            {
                _transitions[i].UpdateTransitionPhysics();
            }
            _subState?.UpdateStatePhysics();
        }


        private void InitSubState()
        {
            for (int i = 0; i < _subStateTransitions.Count; i++)
            {
                _subStateTransitions[i].UpdateTransitionPhysics();
                _subStateTransitions[i].UpdateTransition();
            }
        }


        protected void SetMasterState(StateFH state)
        {
            _masterState = state;
        }
        public void SetSubState(StateFH state)
        {
            _subState = state;
            _subState.SetMasterState(this);
        }
    }
}
