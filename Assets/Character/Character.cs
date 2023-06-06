using System;
using UnityEngine;

namespace GeneralPurpose2d
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private Stats _stats;
        public Stats Stats { get => _stats; }

        public Action<float> MoveEvent;
    }
}
