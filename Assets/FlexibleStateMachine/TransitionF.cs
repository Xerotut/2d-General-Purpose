using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace GeneralPurpose2d
{
    public abstract class TransitionF
    {
        public event Action Callback;

        public abstract bool CheckCondition();

        public virtual void Enter() { }
        public virtual void Exit() { }

        public void UpdateTransition()
        {
            if (!CheckCondition()) return;

            if (Callback != null)
            {
                Callback.Invoke();
            }
            else
            {
                Enter();
            }
        }

     
    }
}
