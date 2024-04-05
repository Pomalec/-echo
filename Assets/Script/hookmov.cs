using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class hookmov : MonoBehaviour
{
  
    Vector3 startPos;
   
    fishmov fish;
    bool failed;
    bool catching;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        catching = false;
        failed = false;
        Physics2D.IgnoreCollision(GameObject.FindWithTag("junk").GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // zero z
        mouseWorldPos.x = 0f; // zero x
        if (mouseWorldPos.y<=4f && mouseWorldPos.y>=-4.5f)
        {
            transform.position = mouseWorldPos;
        }
        if (mouseWorldPos.y >= 2f&&catching&&failed==false)
        {
            if (Input.GetMouseButtonDown(0))
            {

                catching = false;
                Physics2D.IgnoreCollision(GameObject.FindWithTag("junk").GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }
        //Debug.Log(" "+mouseWorldPos.y +" ");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fish" && catching== false)
        {
            catching = true;
            Physics2D.IgnoreCollision(GameObject.FindWithTag("junk").GetComponent<Collider2D>(), GetComponent<Collider2D>(),false);

        }
        if (collision.gameObject.tag == "junk" && catching == true)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            failed = true;
            catching= false;

        }
    }
  ///  void OnCollisionExit2D(Collision2D collision)
  ///  {
  ///      if (collision.gameObject.tag == "fish" )
  ///      {
  ///          catching = false;
  ///
  ///      }
  ///  }
    public bool getcatching()
    {
        return catching;
    }
    public bool getfailed()
    {
        return failed;
    }
    public void restartfailed()
    {
        this.failed = false;
    }
}
