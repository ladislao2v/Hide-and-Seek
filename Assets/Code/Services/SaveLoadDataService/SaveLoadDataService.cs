using Code.Services.ResourceBankService;
using Newtonsoft.Json;
using UnityEngine;

namespace Code.Services.SaveLoadDataService
{
    public class SaveLoadDataService : ISaveLoadDataService
    {
        public void Save<TSavable>(TSavable data)
        {
            string json = JsonConvert.SerializeObject(data);

            PlayerPrefs.SetString(typeof(TSavable).ToString(), json);
            PlayerPrefs.Save();
            
            Debug.Log("Save is done!");
        }

        public TLoadable Load<TLoadable>()
        {
            string json = PlayerPrefs.GetString(typeof(TLoadable).ToString());

            TLoadable loadable = JsonConvert.DeserializeObject<TLoadable>(json);
            
            if(loadable != null)
                Debug.Log("Load is done");
            
            return loadable;
        }
    }
}