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
    GameObject otherfish;
    void Start()
    {
        hookavailable = true;
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
}
