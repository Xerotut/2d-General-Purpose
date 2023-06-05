using System;
using UnityEngine;

namespace GeneralPurpose2d
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterStats _stats;
        public CharacterStats Stats { get => _stats; }

        public Action<float> MoveEvent;
    }
}
