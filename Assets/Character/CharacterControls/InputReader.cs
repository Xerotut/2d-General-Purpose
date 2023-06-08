using System;
using UnityEngine;

namespace GeneralPurpose2d
{
    public static class InputReader 
    {

        private static PlayerInput _playerInput;

        public static event Action<Vector2> OnMove;
        public static event Action<bool> OnWalk;
        public static event Action OnFly;

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

            _playerInput.Character.Walk.performed += ctx => OnWalk?.Invoke(true);
            _playerInput.Character.Walk.canceled += ctx => OnWalk?.Invoke(false);

            _playerInput.Character.Fly.performed += ctx => OnFly?.Invoke();

        }

    }
}
