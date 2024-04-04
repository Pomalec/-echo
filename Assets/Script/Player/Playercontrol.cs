using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float movspeed;
    float speedx, speedy;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedx = Input.GetAxisRaw("Horizontal") * movspeed;
        speedy = Input.GetAxisRaw("Vertical") * movspeed;
        rb.velocity=new Vector2 (speedx, speedy);
    }
}
