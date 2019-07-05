using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string gameToBeLoaded;

    public void PlayGame()
    {
        Application.LoadLevel(gameToBeLoaded);
    }

    public void ExitGame()
    {
        Application.Quit();

    }
}
