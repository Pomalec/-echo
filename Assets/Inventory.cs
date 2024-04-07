using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum ItemType
    {
        Rod,
        Cobweb,
        FishingMinigame,
        BookMinigame
    }

    [SerializeField]
    private static int cobwebs;

    private List<ItemType> _items = new List<ItemType>();

    public bool MiniGamesComplete => CheckInventory(ItemType.FishingMinigame) && CheckInventory(ItemType.BookMinigame);

    public int CobwebCount => cobwebs; 

    private static Inventory _instance;

    public static Inventory Instance => _instance;

    private void Awake()
    {
        cobwebs = 0;
        DontDestroyOnLoad(gameObject);

        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    public void AddItem(ItemType item)
    {
        _items.Add(item);
        if (item==ItemType.Cobweb)
        {
            cobwebs++;
            Debug.Log(cobwebs);
        }
    }
    
    public bool CheckInventory(ItemType item)
    {
        return _items.Contains(item);
    }
}
