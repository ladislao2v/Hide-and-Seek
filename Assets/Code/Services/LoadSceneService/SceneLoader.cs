using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Code.Services.LoadSceneService
{
    public class SceneLoader : ILoadSceneService
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Load(string sceneName, Action loaded = null) 
            => _coroutineRunner.StartCoroutine(LoadScene(sceneName, loaded));

        private IEnumerator LoadScene(string name, Action loaded = null)
        {
            var waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
                yield return null;

            loaded?.Invoke();
        }
    }
}