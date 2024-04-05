using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class jellymov : MonoBehaviour
{
    Vector3 startPos;
    public UnityEvent scored;

    Rigidbody2D rb;
    bool attack;
    bool hookavailable;
    [SerializeField]
    private float speed;
    bool facing;//true right //false left 
    GameObject otherfish;
    void Start()
    {
        hookavailable = true;
        attack = false;
        startPos = this.transform.position;
        if (startPos.x < 0)
        {
            facing = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else { facing = true; }
        rb = GetComponent<Rigidbody2D>();
        // otherfish = GameObject.FindWithTag("fish");
        //Physics2D.IgnoreCollision(otherfish.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //Physics2D.IgnoreCollision(GameObject.FindWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GameObject.FindWithTag("junk").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        
        
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "junk" || collision.gameObject.tag == "fish" || collision.gameObject.tag == "jellyfish")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }


    }
    void Update()
    {
       

        if (!facing)
        {
            rb.velocity = transform.right * speed;

        }
        else
        {
            rb.velocity = -transform.right * speed;

        }
     ///   if (transform.position.x<=0f&& transform.position.x >= -1 && GameObject.FindWithTag("Player").GetComponent<hookmov>().getposy() <= transform.position.y &&
     //      GameObject.FindWithTag("Player").GetComponent<hookmov>().getcatching() && attack == false)
     //  {
     //      Debug.Log("jellyfish");
     //      //GameObject.FindWithTag("Player").GetComponent<hookmov>().setfailed();
     //      attack = true;
     //  
     //  }
     //  if (attack)
     //  {
     //      GameObject.FindWithTag("Player").GetComponent<hookmov>().restartfailed();
     //  }


    }
    public float getposx()
    {
        float currentx;
         currentx= transform.position.x;
        return currentx;
    }
    public float getposy()
    {
        float currenty;
        currenty = transform.position.y;
        return currenty;
    }
}
