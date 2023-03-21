using InternalAssets.UI;
using UnityEngine;

namespace InternalAssets.FinishLine
{
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] private UISystem uiSystem;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Player.Scripts.Player>() != null)
                uiSystem.ShowYouWinScreen();
        }
    }
}
