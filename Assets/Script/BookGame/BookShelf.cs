using System.Collections;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int _bookShelfIndex;

    [SerializeField] private Book _placedBook;
    private Coroutine _waitForInputCoroutine;

    [SerializeField]
    private int type;
    private int typedummy;
    bool col;
    public Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        col = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _waitForInputCoroutine = StartCoroutine(WaitForInput());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_waitForInputCoroutine != null)
        {
            StopCoroutine(_waitForInputCoroutine);
        }
    }

    private IEnumerator WaitForInput()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
                break;
            }
            yield return null;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (_bookShelfIndex == type)
    //    {

    //        Inventory.Instance.AddItem(Inventory.ItemType.BookMinigame);
    //    }
    //    else
    //    {
    //        Inventory.Instance.RemoveItem(Inventory.ItemType.BookMinigame);
    //    }
    //    if (col)
    //    {
    //        if (Input.GetKeyDown(KeyCode.F))
    //        {

    //            typedummy = GameObject.FindWithTag("Player").GetComponent<bookinventory>().getbooksel();
    //            GameObject.FindWithTag("Player").GetComponent<bookinventory>().setbooksel(type);
    //            type = typedummy;
    //            col = false;
    //        }
    //    }

    //    if (type == 0)
    //    {
    //        anim.SetBool("empty", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("empty", false);
    //    }
    //}

    public int gettype()
    {
        return type;
    }

    private void Interact()
    {
        if (_placedBook == null && bookinventory.Book != null)
        {
            PlaceBook();
        }
        else if (_placedBook != null && bookinventory.Book != null)
        {
            SwapBook();
        }
        else
        {
            RemoveBook();
        }
    }

    private void RemoveBook()
    {
        bookinventory.Book = _placedBook;
        _placedBook = null;
        anim.SetBool("empty", true);
    }

    private void SwapBook()
    {
        var temp = bookinventory.Book;
        bookinventory.Book = _placedBook;
        _placedBook = temp;
        CheckBookPlacement();
    }

    private void PlaceBook()
    {
        anim.SetBool("empty", false);
        _placedBook = bookinventory.Book;
        bookinventory.Book = null;

        CheckBookPlacement();
    }

    private void CheckBookPlacement()
    {
        BookshelfPuzzle.BookPlaced(_bookShelfIndex, _placedBook.CorrectBookshelfIndex == _bookShelfIndex);
        if (_placedBook.CorrectBookshelfIndex == _bookShelfIndex)
        {
            //play audio
        }
    }
}
