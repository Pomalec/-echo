using System;
using System.Collections;
using UnityEngine;

namespace Echo.Dialog
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] private DialogBox _dialogBox;
        [SerializeField] float _timeBetweenChars = 0.5f;

        private bool _dialogOpen;
        private Action _postDialogAction;

        private static DialogManager s_instance;

        public static DialogManager Instance => s_instance;
        public float TimeBetweenChars => _timeBetweenChars;

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

            _dialogBox.gameObject.SetActive(false);
        }

        public void Show(Dialog dialog, Action action = null)
        {
            if (!Playercontrol.CanInteract) return;

            _dialogBox.gameObject.SetActive(true);
            _dialogBox.LoadDialog(dialog);
            Playercontrol.CanMove = false;
            Playercontrol.CanInteract = false;
            _dialogOpen = true;
            StartCoroutine(WaitForSpeedUp());

            _postDialogAction = action;
        }

        public void Hide()
        {
            _dialogBox.gameObject.SetActive(false);
            Playercontrol.CanMove = true;
            StartCoroutine(WaitToEnableInteractions());
            _dialogOpen = false;
            _postDialogAction?.Invoke();
        }

        private IEnumerator WaitForSpeedUp()
        {
            while (_dialogOpen)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _timeBetweenChars /= 2;
                }
                if (Input.GetKeyUp(KeyCode.E))
                {
                    _timeBetweenChars *= 2;
                }
                yield return null;
            }
        }

        private IEnumerator WaitToEnableInteractions()
        {
            yield return new WaitForSeconds(0.5f);
            Playercontrol.CanInteract = true;
        }
    }
}