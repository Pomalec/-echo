using System.Collections;
using TMPro;
using UnityEngine;

namespace Echo.Dialog
{
    public class DialogBox : MonoBehaviour
    {
        private Dialog _dialog;
        private int _currentLine;

        [SerializeField] private TextMeshProUGUI _dialogText;

        public void LoadDialog(Dialog text)
        {
            _dialog = text;
            _currentLine = 0;
            StartCoroutine(MoveToNext());
            StartCoroutine(WaitForNext());

        }

        public void Hide()
        {
            _dialog = null;
            DialogManager.Instance.Hide();
        }

        private IEnumerator WaitForNext()
        {
            yield return new WaitForSeconds(0.5f);
            //TODO: Change key/input system
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (_currentLine >= _dialog.Lines.Count - 1)
                    {
                        Hide();
                        yield break;
                    }

                    _currentLine++;
                    StartCoroutine(MoveToNext());
                }
                yield return null;
            }
        }

        private IEnumerator MoveToNext()
        {
            var text = _dialog.Lines[_currentLine];
            var displayedText = "";

            for (var i = 0; i < text.Length; i++)
            {
                displayedText += text[i];
                _dialogText.text = displayedText;
                yield return new WaitForSeconds(DialogManager.Instance.TimeBetweenChars);
            }

        }
    }
}