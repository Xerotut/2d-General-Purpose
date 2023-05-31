using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class CharacterMovement : MonoBehaviour
    {
        Character character;

        private void Awake()
        {
            character = GetComponent<Character>();
        }

        private void FixedUpdate()
        {
           // Move();
        }

        private void Move(Vector2 direction, float speed)
        {
            Debug.Log(direction * speed);
        }
    }
}
