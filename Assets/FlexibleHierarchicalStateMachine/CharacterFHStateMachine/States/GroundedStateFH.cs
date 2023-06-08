using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class GroundedStateFH : StateFH
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered GroundedState");
        }
        public override void Exit()
        {
            base.Exit();
            Debug.Log("Exited GroundedState");
        }
    }
}
