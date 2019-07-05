using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DisplayScore : MonoBehaviour
{
    public Text scoreDisplayed;
    private ScoreManager theScoreManager;
  
    public void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        scoreDisplayed.text = "SCORE: " + Mathf.Round(theScoreManager.scoreCount);
      
    }
}