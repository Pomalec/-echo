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
    public static int cobwebs;

    private List<ItemType> _items = new List<ItemType>();

    public bool MiniGamesComplete => CheckInventory(ItemType.FishingMinigame) && CheckInventory(ItemType.BookMinigame);

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

    public bool CheckInventory(ItemType item)
    {
        return _items.Contains(item);
    }
}
