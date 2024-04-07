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
    [SerializeField] private bool book;
    [SerializeField] private bool rod;
    [SerializeField] private bool bush;
    [SerializeField] private bool ending;
    [SerializeField] private Dialog bookb1;
    [SerializeField] private Dialog bookb2;
    [SerializeField] private Dialog bookb3;
    [SerializeField] private Dialog bookb4;
    [SerializeField] private Dialog bookb5;
    [SerializeField] private bool cobwell;
   
    public void TryInteract()
    {
        if (ending)
        {
            if (Inventory.Instance.CobwebCount>7)
            {
                DialogManager.Instance.Show(bookb1); 
            }
            else
            {
                DialogManager.Instance.Show(bookb2); 
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene("mainmenu");
        }
        if (book)
        {
            int booktype = this.gameObject.GetComponent<bookpuzzle>().gettype();
            switch (booktype)
            {
                case 0: DialogManager.Instance.Show(_dialog); break;
                case 1: DialogManager.Instance.Show(bookb1); break;
                case 2: DialogManager.Instance.Show(bookb2); break;
                case 3: DialogManager.Instance.Show(bookb3); break;
                case 4: DialogManager.Instance.Show(bookb4); break;
                case 5: DialogManager.Instance.Show(bookb5); break;
            }

        }
        if (bush)
        {
            int bushtype = this.gameObject.GetComponent<bushpuzzle>().gettype();
            if (bushtype == 1)
            {
                DialogManager.Instance.Show(_dialog);
            }
            else
            {
                TimerScript.bushes += 1;
                Destroy(this.gameObject);
            }

        }
        else
        {
            if (minigame&&Inventory.Instance.CheckInventory(Inventory.ItemType.Rod))//check for rod in the inventory
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
                return;
            }

            if (!isInteractable || !_startsDialog) return;

            DialogManager.Instance.Show(_dialog);

            if (canPickup)
            {
                if (rod)
                {
                    Inventory.Instance.AddItem(Inventory.ItemType.Rod);
                }
                if (cobwell)
                {
                    Inventory.Instance.AddItem(Inventory.ItemType.Cobweb);
                }
                //AudioManager.Instance.Play(Echo.Audio.AudioType.Pickup);
                Destroy(this.gameObject);
            }
        }
    }
}
