using Echo.Dialog;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InteractbleObject : MonoBehaviour
{
    [SerializeField] private bool isInteractable;
    [SerializeField] private bool canPickup;
    [SerializeField] private Dialog _dialog;
    [SerializeField] private bool _startsDialog = true;


    private void Awake()
    {
        //Probaly shouldn't start this until the player is in range
        //StartCoroutine(WaitForInteraction());
    }

    public void TryInteract()
    {
        if (!isInteractable || !_startsDialog) return;
        DialogManager.Instance.Show(_dialog);

        //Maybe destroy after dialog?
        if (canPickup)
        {
            Destroy(gameObject);
        }
    }
}
