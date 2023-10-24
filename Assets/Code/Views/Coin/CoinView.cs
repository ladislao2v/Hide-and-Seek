using Code.Services.ResourceBankService;
using Code.Views.Player;
using UnityEngine;
using Zenject;

namespace Code.Views.Coin
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _count;
        
        private IResourceBankService _bankService;

        [Inject]
        private void Constuct(IResourceBankService bankService)
        {
            _bankService = bankService;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerView playerView))
            {
                _bankService.Add(_count);
            }
        }
    }
}