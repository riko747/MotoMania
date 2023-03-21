using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace InternalAssets.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private GameObject youWinText;
        [SerializeField] private GameObject youLoseText;
        [SerializeField] private Button youWinButton;
        [SerializeField] private Button youLoseButton;

        private void Start()
        {
            youWinButton.onClick.AddListener(ReloadScene);
            youLoseButton.onClick.AddListener(ReloadScene);
        }

        public void ShowYouWinScreen() => youWinText.SetActive(true);

        public void ShowYouLoseScreen() => youLoseText.SetActive(true);

        private void ReloadScene() => SceneManager.LoadScene(0);

        private void OnDestroy()
        {
            youWinButton.onClick.RemoveListener(ReloadScene);
            youLoseButton.onClick.RemoveListener(ReloadScene);
        }
    }
}
