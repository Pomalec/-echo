using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum ItemType
    {
        Rod,
        Cobweb,
        FishingMinigame,
        BookMinigame,
        skateboard
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
        
    }
    public void RemoveItem(ItemType item)
    {
        if (_items.Contains(ItemType.BookMinigame))
        {
            _items.Remove(item);
        }
        
        
    }
    public bool CheckInventory(ItemType item)
    {
        return _items.Contains(item);
    }
}
