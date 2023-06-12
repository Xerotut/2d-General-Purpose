using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public abstract class StateH
    {

        protected StateH _masterState;
        protected StateH _subState;


        public virtual void EnterState() => _subState = null;

        public virtual void UpdateState() => _subState?.UpdateState();
        

        public virtual void UpdateStatePhysics() => _subState?.UpdateStatePhysics();

        public virtual void ExitState()
        {
            _subState?.ExitState();
            _masterState = null;
        }

        
        protected void SetMasterState(StateH state)
        {
            _masterState = state;
        }
        public void SetSubState(StateH state)
        {
            _subState = state;
            _subState.SetMasterState(this);
        }
    }
}
