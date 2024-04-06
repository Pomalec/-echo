using System.Collections;
using System.Collections.Generic;
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
    }
    public void home()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("orangenodes");
        Time.timeScale = 1;
    }
    public void resume()
    {
        pausem.SetActive(false);
        Time.timeScale = 1;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
