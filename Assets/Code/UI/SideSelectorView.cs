using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
    public class SideSelectorView : MonoBehaviour
    {
        [SerializeField] private Button _hideButton;
        [SerializeField] private Button _seekButton;

        public Button HideButton => _hideButton;
        public Button SeekButton => _seekButton;
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public class Factory : PlaceholderFactory<SideSelectorView>
        {
            
        }
    }
}