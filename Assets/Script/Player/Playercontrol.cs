using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float movspeed;
    float speedx, speedy;
    Rigidbody2D rb;

    public static bool CanMove { get; set; } = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanMove)
        {
            if (rb.velocity != Vector2.zero)
            {
                rb.velocity = Vector2.zero;
            }
            return;
        }

        speedx = Input.GetAxisRaw("Horizontal") * movspeed;
        speedy = Input.GetAxisRaw("Vertical") * movspeed;
        rb.velocity = new Vector2(speedx, speedy);
    }
}
