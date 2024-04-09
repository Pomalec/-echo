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
    private hookmov _hook;

    void Start()
    {
        _hook = FindObjectOfType<hookmov>();

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

    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "playerhook" && catched == false)
        {
            if (hookavailable)
            {
                catched = false;
            }
            else
                catched = true;
        }

        if (catched)
        {
            if (collider.TryGetComponent(out jellymov _))
            {
                _hook.NotifyJellyHit();
                Destroy(gameObject);
            }

            if (collider.TryGetComponent(out junkmov _))
            {
                _hook.ResetHook();
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if (_hook.getfailed())
        {
            _hook.restartfailed();
        }

        if (!_hook.getcatching())
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
            transform.position = _hook.HookImage.transform.position;

            if (transform.position.y >= 3f)
            {

                switch (type)
                {
                    case 0: scoremanager.scorecount0 -= 1; break;
                    case 1: scoremanager.scorecount1 += 1; break;
                    case 2: break;
                    case 3: break;
                    case 4: break;
                }
                Destroy(gameObject);
            }
        }


    }

}
