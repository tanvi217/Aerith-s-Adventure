using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public string mainMenu;

    public void Restart()
    {
        FindObjectOfType<GameManager1>().Reset();
    }

    public void BackToMain()
    {
        Application.LoadLevel(mainMenu);
    }
}
