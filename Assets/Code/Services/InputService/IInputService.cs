using UnityEngine;

namespace Code.Services.InputService
{
    public interface IInputService
    {
        public Vector3 Direction { get; }

        void Enable();
        void Disable();
    }
}