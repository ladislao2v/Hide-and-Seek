using JetBrains.Annotations;
using UnityEngine;

namespace Code.Services.CameraFollowService
{
    public class CameraFollower : MonoBehaviour, ICameraFollowService
    {
        [SerializeField] private float _returnSpeed;
        [SerializeField] private float _height;
        [SerializeField] private float _rearDistance;
        
        [CanBeNull] private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void LateUpdate()
        {
            Follow();
        }

        public void Follow()
        {
            if (_target == null)
                return;
            
            var position = 
                new Vector3(_target.position.x, _target.position.y + _height, _target.position.z - _rearDistance);

            transform.position = Vector3.Lerp(transform.position, position, _returnSpeed * Time.deltaTime);
        }
    }
}