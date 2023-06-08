using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class FlyInput : TransitionFH
    {
        public FlyInput() 
        {
            InputReader.OnFly += PressedFlyButton;
        }
        
        private void PressedFlyButton()
        {
         //   Callback?.Invoke();
        }

    }
}
