using Echo.Dialog;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Collider2D))]
public class InteractbleObject : MonoBehaviour
{
    [SerializeField] private bool isInteractable;
    [SerializeField] private bool canPickup;
    [SerializeField] private Dialog _dialog;
    [SerializeField] private bool _startsDialog = true;
    [SerializeField] private bool minigame;

    private void Awake()
    {
        //Probaly shouldn't start this until the player is in range
        //StartCoroutine(WaitForInteraction());
    }

    public void TryInteract()
    {
        if (!isInteractable || !_startsDialog) return;
        DialogManager.Instance.Show(_dialog);
        if (minigame)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        //Maybe destroy after dialog?
        if (canPickup)
        {
            Destroy(gameObject);
        }
    }
}
