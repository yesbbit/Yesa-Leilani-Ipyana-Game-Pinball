using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball_Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
