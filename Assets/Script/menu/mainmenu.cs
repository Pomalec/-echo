using Echo.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    public void playgame()
    {
        AudioManager.Instance.ChangeBgm(BgmType.Cave);
        SceneManager.LoadSceneAsync(7);
    }

    public void quitgame()
    {
        Application.Quit();
    }
}
