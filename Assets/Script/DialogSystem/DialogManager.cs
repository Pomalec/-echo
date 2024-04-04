using System.Collections;
using UnityEngine;

namespace Echo.Dialog
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] private DialogBox _dialogBox;
        [SerializeField] float _timeBetweenChars = 0.05f;

        private static DialogManager s_instance;
        private static float s_timeBetweenChars;

        public static DialogManager Instance => s_instance;
        public static float TimeBetweenChars => s_timeBetweenChars;

        private void Awake()
        {
            if (s_instance == null)
            {
                s_instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            s_timeBetweenChars = _timeBetweenChars;
            _dialogBox.gameObject.SetActive(false);
        }

        public void Show(Dialog dialog)
        {
            if (!Playercontrol.CanInteract) return;

            _dialogBox.gameObject.SetActive(true);
            _dialogBox.LoadDialog(dialog);
            Playercontrol.CanMove = false;
            Playercontrol.CanInteract = false;
        }

        public void Hide()
        {
            _dialogBox.gameObject.SetActive(false);
            Playercontrol.CanMove = true;
            StartCoroutine(WaitToEnableInteractions());
        }

        private IEnumerator WaitToEnableInteractions()
        {
            yield return new WaitForSeconds(0.5f);
            Playercontrol.CanInteract = true;
        }
    }
}