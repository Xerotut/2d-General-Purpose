using System;
using UnityEngine;

namespace GeneralPurpose2d
{
    public static class InputReader 
    {

        private static PlayerInput _playerInput;

        public static event Action<Vector2> OnMove;

        [RuntimeInitializeOnLoadMethod]
        private static void PrepareInputReading()
        {
            _playerInput = new PlayerInput();

            SubscribeToInputs();

            _playerInput.Enable();

        }

        //Modify this as necessary 
        private static void SubscribeToInputs()
        {
            _playerInput.Character.Move.performed += ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
            _playerInput.Character.Move.canceled += ctx => OnMove?.Invoke(Vector2.zero);
        }

    }
}
