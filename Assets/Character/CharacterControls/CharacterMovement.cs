using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralPurpose2d
{
    public class CharacterMovement : MonoBehaviour
    {
        public void Move(Rigidbody2D rb, float speed, Vector2 direction)
        {
            rb.velocity = direction * speed;
        }
    }
}
