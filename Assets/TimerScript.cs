using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public static int bushes;
    public TextMeshProUGUI TimerTxt;

    void Start()
    {
        bushes = 0;
        TimerOn = true;
    }

    void Update()
    {
        if (bushes == 5)
        {
            TimerOn = false;
            SceneManager.LoadScene("ending");
        }
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}