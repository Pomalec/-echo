using System.Collections;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float movspeed;
    float speedx, speedy;
    Rigidbody2D rb;
    private bool _running = false;

    [SerializeField] private float _runSpeedModifier = 2;

    public static bool CanMove { get; set; } = true;
    public static bool CanInteract { get; set; } = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ListenForRunInput());
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanMove)
        {
            if (rb.velocity != Vector2.zero)
            {
                rb.velocity = Vector2.zero;
                speedx = 0;
                speedy = 0;
            }
            return;
        }

        speedx = Input.GetAxisRaw("Horizontal") * movspeed;
        speedy = Input.GetAxisRaw("Vertical") * movspeed;



    }

    private void FixedUpdate()
    {
        var speedModifier = _running ? _runSpeedModifier : 1;
        rb.velocity = new Vector2(speedx, speedy) * speedModifier;
    }

    private IEnumerator ListenForRunInput()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _running = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _running = false;
            }
            yield return null;
        }
    }
}