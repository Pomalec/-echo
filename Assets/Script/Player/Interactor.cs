using System.Collections;
using UnityEngine;

namespace Echo.Player
{
    public class Interactor : MonoBehaviour
    {
        private Coroutine _interactionCoroutine;
        private InteractbleObject _interactbleObject;

        [SerializeField] private KeyCode _interactKey = KeyCode.Space;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out InteractbleObject interactble))
            {
                _interactbleObject = interactble;
                _interactionCoroutine = StartCoroutine(WaitForInteraction());
            }
        }

        private IEnumerator WaitForInteraction()
        {
            while (true)
            {
                if (Input.GetKeyDown(_interactKey) && Playercontrol.CanInteract)
                {
                    _interactbleObject.TryInteract();
                }
                yield return null;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out InteractbleObject interactble))
            {
                if (_interactionCoroutine != null)
                {
                    StopCoroutine(_interactionCoroutine);
                }
            }
        }
    }
}