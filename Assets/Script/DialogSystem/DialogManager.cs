using UnityEngine;

namespace Echo.Dialog
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] private DialogBox _dialogBox;
        [SerializeField] float _timeBetweenChars = 0.05f;

        private static DialogBox s_dialogBox;
        private static float s_timeBetweenChars;

        public static DialogBox Box => s_dialogBox;
        public static float TimeBetweenChars => s_timeBetweenChars;

        private void Awake()
        {
            s_timeBetweenChars = _timeBetweenChars;
            s_dialogBox = _dialogBox;
            s_dialogBox.gameObject.SetActive(false);
        }

        public static void Show(Dialog dialog)
        {
            s_dialogBox.gameObject.SetActive(true);
            s_dialogBox.LoadDialog(dialog);
            Playercontrol.CanMove = false;
        }

        public static void Hide()
        {
            s_dialogBox.gameObject.SetActive(false);
            Playercontrol.CanMove = true;
        }
    }
}