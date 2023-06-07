using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public abstract class StateF
    {

        private List<TransitionF> _transitions = new();

        public void AddTransition(TransitionF transition)
        {
            _transitions.Add(transition);
        }

        public virtual void Enter()
        {
            for (int i = 0; i < _transitions.Count; i++)
            {
                _transitions[i].Enter();
            }
        }

        public virtual void Exit()
        {
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
        }
        public virtual void UpdateStatePhysics()
        {
            
        }
    }
}
