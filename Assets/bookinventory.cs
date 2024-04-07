using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookinventory : MonoBehaviour
{
    // Start is called before the first frame update
   // [SerializeField] GameObject book1;
   // [SerializeField] GameObject book2;
   // [SerializeField] GameObject book3;
   // [SerializeField] GameObject book4;
   // [SerializeField] GameObject book5;
    private bookpuzzle b;
    int booksel;
    void Start()
    {
        booksel = 0;
    }
   // private void OnCollisionEnter2D(Collision2D collision)
   // {
   //     if (Input.GetKeyDown(KeyCode.Space))
   //     {
   //         if (collision.gameObject.tag == "book")
   //         {
   //             b=collision.gameObject.GetComponent<bookpuzzle>();
   //             booksel = b.gettype();
   //         }
   //        
   //     }
   // }
    public int getbooksel()
    {
        return booksel;
    }
    public void setbooksel(int bo)
    {
        this.booksel=bo;
    }
    // Update is called once per frame
    void Update()
    {
        switch (booksel)
        {
            case 0:;break;
            case 1:;break;
            case 2:;break;
            case 3:; break;
            case 4:;break;
            case 5:;break;
        }
    }
}
