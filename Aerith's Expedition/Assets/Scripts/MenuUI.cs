using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    private SceneTransition sceneTransition;

    private void Start()
    {
        sceneTransition = GameObject.FindGameObjectWithTag("Scene Transition").GetComponent<SceneTransition>();
        if (sceneTransition == null)
            Debug.LogError("asddf");
    }

    public void Play()
    {
        Debug.Log("asd");
        sceneTransition.InitiateTransition();
        StartCoroutine(LoadScene());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadScene()
    {
        Debug.Log("asasdd");

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Endless");
    }
}
