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
        Physics2D.IgnoreCollision(GameObject.FindWithTag("junk").GetComponent<Collider2D>(), GetComponent<Collider2D>());
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
}
