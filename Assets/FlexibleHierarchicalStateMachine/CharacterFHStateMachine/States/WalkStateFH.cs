using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class WalkStateFH : StateFH
    {
        private event Action<float> HandleMoveInput;
        private readonly float _speed;

        public WalkStateFH(Character character, float moveSpeed)
        {
            HandleMoveInput += speed => character.MoveEvent?.Invoke(speed);
            _speed = moveSpeed;
        }

        public override void UpdateStatePhysics()
        {
            HandleMoveInput.Invoke(_speed);
            base.UpdateStatePhysics();
        }
    }
}
