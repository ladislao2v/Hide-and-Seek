using UnityEngine;

namespace Code.Services.InputService
{
    public class MobileInputService : IInputService
    {
        private readonly Joystick _joystick;

        public Vector3 Direction => new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        public MobileInputService(Joystick joystick)
        {
            _joystick = joystick;
        }

        public void Enable()
        {
            _joystick.gameObject.SetActive(true);
        }

        public void Disable()
        {
            _joystick.gameObject.SetActive(false);
        }
    }
}