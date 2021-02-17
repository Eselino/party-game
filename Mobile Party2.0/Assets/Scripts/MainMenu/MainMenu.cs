using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Singleplayer()
    {
        SceneManager.LoadScene("RockPaperScissors"); // All of these examples loads "Level_0"
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
