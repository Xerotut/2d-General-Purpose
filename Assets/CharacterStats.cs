using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        public float MoveSpeed { get => _moveSpeed; }
        [SerializeField] float _walkSpeed;
        public float WalkSpeed { get => _walkSpeed; }
    }
}
