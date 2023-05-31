using Unity.VisualScripting;
using UnityEngine;

namespace GeneralPurpose2d
{
    public abstract class CharacterBaseState 
    {



        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void UpdateStatePhysics();
        public abstract void ExitState();


    }
}
