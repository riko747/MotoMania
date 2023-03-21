using System.Linq;
using InternalAssets.Control.Scripts;
using InternalAssets.UI;
using UnityEngine;

namespace InternalAssets.Player.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private Rigidbody2D rigidBody2D;
        [SerializeField] private Collider2D boxCollider2D;
        [SerializeField] private Collider2D circleCollider2D;
        [SerializeField] private ButtonControl movementButtonControl;
        [SerializeField] private ButtonControl tiltUpButtonControl;
        [SerializeField] private ButtonControl tiltDownButtonControl;

        private const float MovementSpeed = 20f;
        private bool _playerOnGround;

        private void FixedUpdate()
        {
            if (movementButtonControl.IsButtonHeld && _playerOnGround)
                rigidBody2D.AddForce(transform.right * (MovementSpeed * Time.deltaTime), ForceMode2D.Impulse);

            if (tiltUpButtonControl.IsButtonHeld)
                transform.Rotate(new Vector3(0, 0, 20), 360 * Time.deltaTime, Space.Self);

            if (tiltDownButtonControl.IsButtonHeld)
                transform.Rotate(new Vector3(0, 0, -20), 360 * Time.deltaTime, Space.Self);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var collisionWithHead = collision.contacts[0].otherCollider == circleCollider2D;
            
            if (collisionWithHead)
                uiSystem.ShowYouLoseScreen();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            var collisionWithWheels = collision.contacts.Any(contactPoint2D => contactPoint2D.otherCollider == boxCollider2D);

            _playerOnGround = collisionWithWheels;
        }

        private void OnCollisionExit2D(Collision2D collision) => _playerOnGround = false;
    }
}
