using System.Collections.Generic;
using UnityEngine;

public class BookshelfPuzzle : MonoBehaviour
{
    const int SHELF_COUNT = 5;

    private static Dictionary<int, bool> s_placedBooks = new Dictionary<int, bool>
    {
        { 0, false },
        { 1, false },
        { 2, false },
        { 3, false },
        { 4, false }
    };

    public static int s_correctBooksPlaced = 0;

    public static void BookPlaced(int shelfIndex, bool correct)
    {
        s_placedBooks[shelfIndex] = correct;

        foreach (var book in s_placedBooks)
        {
            if (!book.Value)
            {
                return;
            }
        }
        Inventory.Instance.AddItem(Inventory.ItemType.BookMinigame);
    }

    private void OnDisable()
    {
        s_correctBooksPlaced = 0;
    }
}