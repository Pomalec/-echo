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
       // Physics2D.IgnoreCollision(GameObject.FindWithTag("junk").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //Physics2D.IgnoreCollision(GameObject.FindWithTag("jellyfish").GetComponent<Collider2D>(), GetComponent<Collider2D>());
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
                
            }
        }
      //  if (GameObject.FindWithTag("junk").GetComponent<junkmov>().getposx()<=0f&&
          //  GameObject.FindWithTag("junk").GetComponent<junkmov>().getposx() >=-1f &&
          //  GameObject.FindWithTag("junk").GetComponent<junkmov>().getposy()- (GameObject.FindWithTag("junk").GetComponent<junkmov>().getsizey())/2<= mouseWorldPos.y &&
          //  GameObject.FindWithTag("junk").GetComponent<junkmov>().getposy() + (GameObject.FindWithTag("junk").GetComponent<junkmov>().getsizey()) / 2 >= mouseWorldPos.y)
        //{
            //failed = true;
            //catching = false;
        //}
        //Debug.Log(" "+mouseWorldPos.y +" ");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fish" && catching== false&&failed==false)
        {
            catching = true;
            
            Debug.Log("si collision ");
        }
        if (collision.gameObject.tag == "junk" && catching == true)
        {
           Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(),true);
            failed = true;
            catching= false;
            Debug.Log("no collision 2");
        }
        if (collision.gameObject.tag == "jellyfish" )
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
            if (catching==true)
            {
                failed = true;
                catching = false;
                Debug.Log("no collision 2");
            }
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; // zero z
            mouseWorldPos.x = 0f; // zero x
            mouseWorldPos.y= 4f; //
            transform.position = mouseWorldPos;
            scoremanager.lives -= 1;
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
    public void setfailed()
    {
        this.failed = true;
        catching = false;
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
}
