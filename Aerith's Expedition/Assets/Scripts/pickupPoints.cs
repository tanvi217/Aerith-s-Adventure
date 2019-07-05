using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoints : MonoBehaviour
{
    public int scoreToGive;

    private ScoreManager theScoreManager;
    private AudioSource coinSound;
    void Start() {
        theScoreManager = FindObjectOfType<ScoreManager>();
        coinSound = GameObject.Find("CoinCollect").GetComponent<AudioSource>();
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Aerith (1)") {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
            coinSound.Play();
        }
    }
}
