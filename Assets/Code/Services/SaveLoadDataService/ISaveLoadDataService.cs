namespace Code.Services.SaveLoadDataService
{
    public interface ISaveLoadDataService
    {
        void Save<TSavable>(TSavable data);
        TLoadable Load<TLoadable>();
    }
}