using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pausem;
    public void pause()
    {
        pausem.SetActive(true);
        Time.timeScale = 0;
        Playercontrol.CanMove = false;
    }
    public void home()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("orangenodes");
        Resume();
    }
    public void HideMenu()
    {
        pausem.SetActive(false);
        Resume();
    }

    private void Resume()
    {
        Time.timeScale = 1;
        Playercontrol.CanMove = true;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
