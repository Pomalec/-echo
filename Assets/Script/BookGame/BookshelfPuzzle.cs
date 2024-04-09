using Echo.Audio;
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

    public static void BookPlaced(int shelfIndex, bool correct)
    {
        s_placedBooks[shelfIndex] = correct;

        if (correct)
        {
            AudioManager.Instance.Play(Echo.Audio.AudioType.CorrectBookPlace);
        }
        else
        {
            AudioManager.Instance.Play(Echo.Audio.AudioType.CorrectBookPlace);
        }

        foreach (var book in s_placedBooks)
        {
            if (!book.Value)
            {
                return;
            }
        }
        Inventory.Instance.AddItem(Inventory.ItemType.BookMinigame);
        AudioManager.Instance.Play(Echo.Audio.AudioType.TaskComplete);
        AudioManager.Instance.ChangeBgm(BgmType.PostTask1);
    }

    private void OnDisable()
    {
        s_placedBooks = null;
    }
}