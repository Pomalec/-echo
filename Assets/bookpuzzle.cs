using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookpuzzle : MonoBehaviour
{
    // Start is called before the first frame update
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Player") 
        {
            
            col = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            col = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (col) {
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                typedummy = GameObject.FindWithTag("Player").GetComponent<bookinventory>().getbooksel();
                GameObject.FindWithTag("Player").GetComponent<bookinventory>().setbooksel(type);
                type = typedummy;
                col = false;
            }
        }
        
        if (type==0)
        {
            anim.SetBool("empty", true);
        }
        else
        {
            anim.SetBool("empty", false);
        }
    }
    public int gettype()
    {
        return type;
    }
}
