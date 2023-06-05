using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        public Character Character { get; private set; }

        private Rigidbody2D _charRB;

        private Vector2 _moveInput;


        private void Awake()
        {
            Character = GetComponent<Character>();

            _charRB = GetComponent<Rigidbody2D>();
            InputReader.OnMove += HandleMoveInput;
            Character.MoveEvent += Move;
        }

        private void HandleMoveInput(Vector2 moveInput)
        {
            _moveInput = moveInput;
        }

        public void Move(float speed)
        {
            _charRB.velocity = _moveInput * speed;
        }
    }
}
