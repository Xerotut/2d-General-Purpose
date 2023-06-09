using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class FlyingStateFH : StateFH
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered FlyingState");
        }
        public override void Exit()
        {
            base.Exit();
            Debug.Log("Exited FlyingState");
        }
    }
}
