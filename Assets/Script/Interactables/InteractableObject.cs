using Echo.Audio;
using Echo.Dialog;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class InteractbleObject : MonoBehaviour
{
    [SerializeField] private bool isInteractable;
    [SerializeField] private bool canPickup;
    [SerializeField] private Dialog _dialog;
    [SerializeField] private bool _startsDialog = true;
    [SerializeField] private bool minigame;
    public void TryInteract()
    {
        if (minigame)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            return;
        }

        if (!isInteractable || !_startsDialog) return;
        DialogManager.Instance.Show(_dialog);
        //Maybe destroy after dialog?
        if (canPickup)
        {
            AudioManager.Instance.Play(Echo.Audio.AudioType.Pickup);
            Destroy(gameObject);
        }
    }
}
