using Echo.Dialog;
using UnityEngine;

[CreateAssetMenu(fileName = "New Book", menuName = "ScriptableObjects/Book")]
public class Book : ScriptableObject
{
    [SerializeField] private Dialog _dialog;

    [SerializeField] private int _correctBookshelfIndex;

    public int CorrectBookshelfIndex => _correctBookshelfIndex;
}