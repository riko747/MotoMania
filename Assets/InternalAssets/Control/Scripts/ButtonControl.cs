using UnityEngine;
using UnityEngine.EventSystems;

namespace InternalAssets.Control.Scripts
{
    public class ButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsButtonHeld { get; private set; }

        public void OnPointerDown(PointerEventData eventData) => IsButtonHeld = true;

        public void OnPointerUp(PointerEventData eventData) => IsButtonHeld = false;
    }
}
