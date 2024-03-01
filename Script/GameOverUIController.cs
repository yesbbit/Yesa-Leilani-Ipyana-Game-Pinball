using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Button mainMenuButton;
    public Button exitButton;

    private void Start()
    {
         mainMenuButton.onClick.AddListener(MainMenu);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
