using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class Character : MonoBehaviour
    {
        [SerializeField] CharacterControls _controls;
        [SerializeField] CharacterStats _stats;
        [SerializeField] CharacterStateMachine _stateMachine;

        public event Action OnUpdateState;
        public event Action OnUpdateStatePhysics;


        private void Update()
        {
            
        }
        private void FixedUpdate()
        {
        }
    }
}
