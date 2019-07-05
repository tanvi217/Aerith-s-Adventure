using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public Aerith thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;
    private AudioSource gamePlayMusic;
    public DeathMenu deathScreen;


    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
        gamePlayMusic = GameObject.Find("GamePlayMusic").GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void RestartGame()
    {
        theScoreManager.isScoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(true);
        gamePlayMusic.Pause();
        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        deathScreen.gameObject.SetActive(false);
        //audioSource.Play();
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.isScoreIncreasing = true;
        gamePlayMusic.Play();

    }
    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.isScoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platformList.Length; i++) {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.isScoreIncreasing = true;
    }*/
}
