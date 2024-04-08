using System.Collections;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float movspeed;
    float speedx, speedy;
    Rigidbody2D rb;
    private bool _running = false;
    [SerializeField] GameObject pausem;
    bool paused = false;
    [SerializeField] private float _runSpeedModifier = 1.5f;

    public static bool CanMove { get; set; } = true;
    public static bool CanInteract { get; set; } = true;
    public Animator animove;

    private static Playercontrol _instance;

    public static Playercontrol Instance => _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1;
        animove = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ListenForRunInput());
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {

            paused = false;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed");
            if (paused == false)
            {
                pausem.SetActive(true);
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                pausem.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }
        }
    }

    private void HidePlayer(bool hidden)
    {
        CanMove = hidden;
        GetComponent<SpriteRenderer>().enabled = hidden;
    }

    private void FixedUpdate()
    {
        if (speedx != 0 || speedy != 0)
        {
            animove.SetFloat("X", speedx);
            animove.SetFloat("Y", speedy);

            animove.SetBool("iswalking", true);
        }
        else
        {
            animove.SetBool("iswalking", false);
        }

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