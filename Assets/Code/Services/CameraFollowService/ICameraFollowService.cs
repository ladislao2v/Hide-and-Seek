using UnityEngine;

namespace Code.Services.CameraFollowService
{
    public interface ICameraFollowService
    {
        void SetTarget(Transform target);
        void Follow();
    }
}