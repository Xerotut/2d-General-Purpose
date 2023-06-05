using System;
using UnityEngine;

namespace GeneralPurpose2d
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        public Action<float> MoveEvent;
    }
}
