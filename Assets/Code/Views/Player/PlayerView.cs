using Code.Services.InputService;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Code.Views.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _speed;
        
        private IInputService _inputService;
        private NavMeshAgent _agent;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            
            _agent.Move(transform.position + _inputService.Direction);
        }

        private void FixedUpdate()
        {
            Move(_inputService.Direction);
        }

        private void Move(Vector3 direction)
        {
            transform.LookAt(transform.position + direction);
            _agent.Move(direction * _speed * Time.fixedDeltaTime);
        }

        public class Factory : PlaceholderFactory<PlayerView>
        {
      
        }
    }
}