using System;

namespace Code.Services.SaveLoadDataService.Data
{
    [Serializable]
    public class ResourceData
    {
        public ResourceData(int coins)
        {
            Coins = coins;
        }

        public int Coins { get; set; }
    }
}