using Echo.Audio;
using UnityEngine;
public class hookmov : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] GameObject pausem;
    bool paused;
    fishmov fish;
    bool failed;
    bool catching;
    private LineRenderer _line;
    private fishmov _fishOnHook;

    [SerializeField] private SpriteRenderer _hookSprite;

    public SpriteRenderer HookImage => _hookSprite;

    void Start()
    {
        paused = false;
        startPos = this.transform.position;
        catching = false;
        failed = false;
        _line = GetComponentInChildren<LineRenderer>();
        _line.positionCount = 2;
        _line.useWorldSpace = true;
        _line.SetPosition(1, new Vector2(1, 4));
    }

    void Update()
    {
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
        if (Time.timeScale == 1)
        {

            paused = false;

            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; // zero z
            mouseWorldPos.x = 0.1248f; // zero x
            if (mouseWorldPos.y <= 4.7223f && mouseWorldPos.y >= -4.5f)
            {
                transform.position = mouseWorldPos;
                _line.SetPosition(0, mouseWorldPos);
                _line.SetPosition(1, new Vector2(0.1248f, 4.7223f));
            }
            if (mouseWorldPos.y >= 3f && catching && failed == false)
            {
                catching = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out fishmov _) && !catching && !failed)
        {
            CatchFish();
            AudioManager.Instance.Play(Echo.Audio.AudioType.FishPickup);
            Debug.Log("si collision ");
        }
    }

    public void ResetHook()
    {
        failed = true;
        catching = false;
    }

    public void NotifyJellyHit()
    {
        if (catching == true)
        {
            ResetHook();
        }

        if (scoremanager.lives - 1 < 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("orangenodes");
        }
        else
        {
            scoremanager.lives -= 1;
            Debug.Log(scoremanager.lives);
        }
    }

    private void CatchFish()
    {
        catching = true;
    }

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
}
