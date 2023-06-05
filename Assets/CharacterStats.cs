using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField] float _runSpeed;
        public float RunSpeed { get => _runSpeed; }
        [SerializeField] float _walkSpeed;
        public float WalkSpeed { get => _walkSpeed; }
    }
}
