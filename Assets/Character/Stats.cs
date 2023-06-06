using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    [CreateAssetMenu(fileName ="Stats", menuName ="General/Stats")]
    public class Stats : ScriptableObject
    {
        [SerializeField] float _runSpeed;
        public float RunSpeed { get => _runSpeed; }
        [SerializeField] float _walkSpeed;
        public float WalkSpeed { get => _walkSpeed; }
    }
}
