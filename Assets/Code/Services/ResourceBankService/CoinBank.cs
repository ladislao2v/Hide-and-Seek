using System;
using Code.Services.SaveLoadDataService;
using Code.Services.SaveLoadDataService.Data;
using UnityEngine;

namespace Code.Services.ResourceBankService
{
    [Serializable]
    public class CoinBank : IResourceBankService, ILoadable, ISavable
    {
        private int _coins;

        public int Value => _coins;
        
        public event Action<int> ValueChanged;
        
        public void Add(int value)
        {
            if (value < 0)
                throw new ArgumentException(nameof(value));

            _coins += value;
            
            ValueChanged?.Invoke(_coins);
        }

        public void Spend(int value)
        {
            if (value >  _coins || value < 0)
                throw new ArgumentException(nameof(value));
            
            _coins -= value;
            
            ValueChanged?.Invoke(_coins);
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            var coinBank = saveLoadDataService.Load<ResourceData>();

            _coins = (coinBank != null) ? coinBank.Coins : 0;

            ValueChanged?.Invoke(_coins);
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService) => 
            saveLoadDataService.Save<ResourceData>(new ResourceData(_coins));
    }
}