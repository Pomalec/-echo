using System.Collections;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float movspeed;
    float speedx, speedy;
    Rigidbody2D rb;
    private Coroutine _interactionCoroutine;
    private InteractbleObject _interactbleObject;

    [SerializeField] private KeyCode _interactKey = KeyCode.Space;

    public static bool CanMove { get; set; } = true;
    public static bool CanInteract { get; set; } = true;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out InteractbleObject interactble))
        {
            _interactbleObject = interactble;
            _interactionCoroutine = StartCoroutine(WaitForInteraction());
        }
    }

    private IEnumerator WaitForInteraction()
    {
        while (true)
        {
            if (Input.GetKeyDown(_interactKey) && CanInteract)
            {
                _interactbleObject.TryInteract();
            }
            yield return null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out InteractbleObject interactble))
        {
            if (_interactionCoroutine != null)
            {
                StopCoroutine(_interactionCoroutine);
            }
        }
    }
}
