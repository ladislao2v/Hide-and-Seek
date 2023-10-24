using System;

namespace Code.Services.LoadSceneService
{
    public interface ILoadSceneService
    {
        void Load(string sceneName, Action loaded = null);
    }
}