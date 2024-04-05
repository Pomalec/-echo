using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class junkmov : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 startPos;
    public UnityEvent scored;

    Rigidbody2D rb;
    bool catched;
    bool hookavailable;
    [SerializeField]
    private float speed;
    bool facing;//true right //false left 
    GameObject otherfish;float sizex, sizey;
    void Start()
    {
        hookavailable = true;
        sizex=GetComponent<Collider2D>().bounds.size.x;
        sizey = GetComponent<Collider2D>().bounds.size.y;
        catched = false;
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
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "jellyfish" || collision.gameObject.tag == "fish" || collision.gameObject.tag == "junk" || collision.gameObject.tag == "Player")
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
        
        


    }
    public float getposx()
    {
        float currentx;
        currentx = transform.position.x;
        return currentx;
    }
    public float getposy()
    {
        float currenty;
        currenty = transform.position.y;
        return currenty;
    }
    public float getsizex()
    {
        
        return sizex;
    }
    public float getsizey()
    {
        
        return sizey;
    }
}
