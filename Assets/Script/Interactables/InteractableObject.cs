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
    [SerializeField] private bool book;
    [SerializeField] private Dialog bookb1;
    [SerializeField] private Dialog bookb2;
    [SerializeField] private Dialog bookb3;
    [SerializeField] private Dialog bookb4;
    [SerializeField] private Dialog bookb5;
    private void Awake()
    {
        //Probaly shouldn't start this until the player is in range
        //StartCoroutine(WaitForInteraction());s
    }
    
    public void TryInteract()
    {
        if (book)
        {
            int booktype=this.gameObject.GetComponent<bookpuzzle>().gettype();
            switch (booktype)
            {
                case 0: DialogManager.Instance.Show(_dialog); break; 
                case 1:DialogManager.Instance.Show(bookb1); break; 
                case 2:DialogManager.Instance.Show(bookb2); break; 
                case 3:DialogManager.Instance.Show(bookb3); break; 
                case 4:DialogManager.Instance.Show(bookb4); break; 
                case 5:DialogManager.Instance.Show(bookb5); break;
            }
            
        }
        else
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
}
