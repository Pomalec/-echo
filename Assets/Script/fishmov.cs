using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class fishmov : MonoBehaviour
{
    // Start is called before the first frame update
    
    Vector3 startPos;
    public UnityEvent scored;
  
    Rigidbody2D rb;
    bool catched;
    bool hookavailable;
    [SerializeField]
    private int type;
    [SerializeField]
    private float speed;
    bool facing;//true right //false left 
    GameObject otherfish;
    void Start()
    {
        hookavailable = true;
        catched = false;
        startPos = this.transform.position;
        if (startPos.x<0)
        {
            facing = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else { facing = true; }
        rb = GetComponent<Rigidbody2D>();
         Physics2D.IgnoreCollision(GameObject.FindWithTag("junk").GetComponent<Collider2D>(),GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GameObject.FindWithTag("fish").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        // otherfish = GameObject.FindWithTag("fish");
        //Physics2D.IgnoreCollision(otherfish.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "junk" || collision.gameObject.tag == "fish" || collision.gameObject.tag == "jellyfish")
        {
            Physics2D.IgnoreCollision(collision.collider,GetComponent<Collider2D>());
        }
        if (collision.gameObject.tag == "Player" && catched == false)
        {
            if (hookavailable)
            {
                catched = false;
            }
            else
                catched = true;
            

        }
        
    }
    void Update()
    {
        if (GameObject.FindWithTag("Player").GetComponent<hookmov>().getfailed())
        {
            Debug.Log("die");
            GameObject.FindWithTag("Player").GetComponent<hookmov>().restartfailed();
            Destroy(this.gameObject);

        }
        if (!GameObject.FindWithTag("Player").GetComponent<hookmov>().getcatching())
        {
            hookavailable = false;
            
        }
        else
        {
            
            hookavailable = true;
        }
        if (!catched)
        {
            if (!facing)
            {
                rb.velocity = transform.right * speed;
                if (transform.position.x > 11f)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                rb.velocity = -transform.right * speed;
                if (transform.position.x < -11f)
                {
                    Destroy(gameObject);
                    hookavailable = true;
                }
            }
        }
        else
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; // zero z
            mouseWorldPos.x = 0f; // zero x
            if (mouseWorldPos.y <= 4f && mouseWorldPos.y >= -4.5f)
            {
                transform.position = mouseWorldPos;
            }
            if (mouseWorldPos.y>=2f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    switch (type)
                    {
                        case 0: scoremanager.scorecount0 += 1; break;
                        case 1: scoremanager.scorecount1 += 1; break;
                        case 2: break;
                        case 3:break; case 4: break;
                    }
                    Destroy(gameObject);
                    
                    
                   
                }
            }
        }


    }
   
}
